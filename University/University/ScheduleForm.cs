﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University
{
    class ScheduleForm : Form
    {
        private University university;
        private Schedule schedule;
        private ComboBox facultyComboBox;
        private ComboBox CourseComboBox;
        private ComboBox GroupsComboBox;
        private Label AlarmLabel;
        private TableLayoutPanel tableLayoutPanel;
        private DataGridView groupShedule;
        private bool isAdmin;

        public ScheduleForm(bool isA)
        {
            this.isAdmin = isA;
            university = University.UniversityInstance;
            schedule = Schedule.ScheduleInstance;
            schedule.LessonAdded += Schedule_LessonAdded;

            facultyComboBox = GetStandardComboBox(new Point(0, 0));
            CourseComboBox = GetStandardComboBox(new Point(facultyComboBox.Right + 20, facultyComboBox.Top));
            GroupsComboBox = GetStandardComboBox(new Point(CourseComboBox.Right + 20, facultyComboBox.Top));
            
            facultyComboBox.SelectedIndexChanged += FacultyComboBoxOnSelectionChangeCommitted;
            CourseComboBox.SelectedIndexChanged += CourseComboBox_SelectionChangeCommitted;
            GroupsComboBox.SelectedIndexChanged += GroupsComboBox_SelectionChangeCommitted;

            AlarmLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(CourseComboBox.Right + 20, facultyComboBox.Top + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                Text = "Nothing schedule for this group",
                ForeColor = System.Drawing.Color.Red,
                Font = new Font("Arial", 10),
                Visible = false,
            };

            groupShedule = new DataGridView()
            {
                Size = new Size(400, 700),
                Location = new Point(0, facultyComboBox.Bottom + 20),
                Dock = DockStyle.Fill,
            };

            for (var i = DayOfWeek.Monday; i <= DayOfWeek.Saturday; i++)
            {
                groupShedule.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name   = i.ToString(),
                    HeaderText = i.ToString(),
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });

            }
            
            groupShedule.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            groupShedule.AllowUserToResizeColumns = false;
            groupShedule.AllowUserToResizeRows = false;
            groupShedule.ReadOnly = true;
            for (int i = 0; i < 7; i++)
            {
                groupShedule.Rows.Add(new DataGridViewRow() {Height = 50,});
            }

            groupShedule.TopLeftHeaderCell.Value = "№";

            tableLayoutPanel = new TableLayoutPanel();

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int i = 0; i < 3; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            }

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            tableLayoutPanel.Dock = DockStyle.Fill;

            var comBoxes = new[] {facultyComboBox, CourseComboBox, GroupsComboBox};

            for (int i = 0; i < 3; i++)
            {
                tableLayoutPanel.Controls.Add(comBoxes[i], i, 0);
            }

            tableLayoutPanel.Controls.Add(AlarmLabel, 3, 0);
            tableLayoutPanel.Controls.Add(groupShedule, 0, 1);
            tableLayoutPanel.SetColumnSpan(groupShedule, 4);

            groupShedule.CellDoubleClick += GroupShedule_DoubleClick;

            Controls.Add(tableLayoutPanel);

            this.Size = new Size(800, 600);

            if (Application.OpenForms.Count == 0) Application.Exit();
            this.Load += ScheduleForm_Load;
        }

        private void Schedule_LessonAdded(object sender, LessonEventArgs e)
        {
            groupShedule[e.Lesson.Day.ToString(), e.Lesson.PairNumber].Value = e.Lesson;
        }

        private void GroupShedule_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isAdmin) return;
            var temp = Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList();
            var day =  temp.Find(week => week.ToString() == groupShedule.Columns[e.ColumnIndex].Name);
            var newLesson = new Lesson()
            {
                
                PairNumber = e.RowIndex + 1,
                Day = day,
                Group = GroupsComboBox.SelectedItem as Group,
            };
            var m = Mode.create;
            if (groupShedule[e.ColumnIndex, e.RowIndex].Value != null)
            {
                newLesson = groupShedule[e.ColumnIndex, e.RowIndex].Value as Lesson;
                m = Mode.edit;
            }
            ChangeLessonForm changeLessonForm = new ChangeLessonForm(newLesson);
            if (changeLessonForm.ShowDialog() == DialogResult.OK)
            {
                if (m == Mode.create)
                {
                    schedule.AddLesson(newLesson);
                }
            }
            UniversitySerializator.SerializeUniversity(university);
            university = UniversitySerializator.DeserializeUniversity();
            var fac = university.Faculties.Find(faculty => faculty.Name == facultyComboBox.SelectedItem.ToString());
            var group = fac.GetFacultyGroups().Find(gr => gr.Name == GroupsComboBox.SelectedItem.ToString());
            var shedule = schedule.GetGroupSchedule(group);
            FillShedule(shedule);
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            facultyComboBox.DataSource = university.Faculties.Select(faculty => faculty.Name).ToList();

            foreach (DataGridViewRow row in groupShedule.Rows)
            {
                row.HeaderCell.Value = $"{row.Index + 1}";
            }
        }

        private void FacultyComboBoxOnSelectionChangeCommitted(object sender, EventArgs eventArgs)
        {
            var temp = university.Faculties[facultyComboBox.SelectedIndex];
            CourseComboBox.DataSource = temp.GetExistingCourses();
        }

        private void CourseComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var fac = university.Faculties.Find(faculty => faculty.Name == facultyComboBox.SelectedItem.ToString());
            var facGr = fac.GetFacultyGroups();
            var temp = facGr.Where(group => group.Course == Convert.ToInt32(CourseComboBox.SelectedItem)).ToList();
            GroupsComboBox.DataSource = temp;
        }

        private void GroupsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var fac = university.Faculties.Find(faculty => faculty.Name == facultyComboBox.SelectedItem.ToString());
            var group = fac.GetFacultyGroups().Find(gr => gr.Name == GroupsComboBox.SelectedItem.ToString());
            var shedule = schedule.GetGroupSchedule(group);
            FillShedule(shedule);
        }


        private void FillShedule(List<Lesson> lessons)
        {
            ClearSchedule(groupShedule);
            AlarmLabel.Visible = lessons.Count == 0;
            foreach (var lesson in lessons)
            {
                var day = lesson.Day.ToString();
                var number = lesson.PairNumber - 1;
                groupShedule[day, number].Value = lesson;
            }
        }

        private void ClearSchedule(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                for (int j = 0; j < dgv.RowCount; j++)
                {
                    dgv[i, j].Value = null;
                }
            }
        }

        private ComboBox GetStandardComboBox(Point location)
        {
           return new ComboBox
            {
                Size = new Size(130, 50),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = location,
            };
        }
    }

    enum Mode
    {
        create,
        edit
    }

}
