using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University
{
    class ScheduleForm : Form
    {
        private University university;
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
            university = UniversityCreator.CreateUniversity();
            facultyComboBox = new ComboBox
            {
                Size = new Size(130, 50),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            CourseComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(facultyComboBox.Right + 20, facultyComboBox.Top),
            };

            GroupsComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(CourseComboBox.Right + 20, facultyComboBox.Top),
            };

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

            facultyComboBox.SelectedIndexChanged += FacultyComboBoxOnSelectionChangeCommitted;
            CourseComboBox.SelectedIndexChanged += CourseComboBox_SelectionChangeCommitted;
            GroupsComboBox.SelectedIndexChanged += GroupsComboBox_SelectionChangeCommitted;

            groupShedule = new DataGridView()
            {
                Size = new Size(400, 700),
                Location = new Point(0, facultyComboBox.Bottom + 20),
                Dock = DockStyle.Fill,
            };

            groupShedule.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Monday", HeaderText = "Monday", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill});
            groupShedule.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Tuesday", HeaderText = "Tuesday",  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            groupShedule.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Wednesday", HeaderText = "Wednesday", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            groupShedule.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Thursday", HeaderText = "Thursday", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            groupShedule.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Friday", HeaderText = "Friday",  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            groupShedule.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Saturday", HeaderText = "Saturday", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            groupShedule.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            groupShedule.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            groupShedule.AllowUserToResizeColumns = false;
            groupShedule.AllowUserToResizeRows = false;

            for (int i = 0; i < 7; i++)
            {
                groupShedule.Rows.Add(new DataGridViewRow(){MinimumHeight = 20});
            }
            
            groupShedule.TopLeftHeaderCell.Value = "№";
            
            tableLayoutPanel = new TableLayoutPanel();

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            tableLayoutPanel.Dock = DockStyle.Fill;

            tableLayoutPanel.Controls.Add(facultyComboBox, 0, 0);
            tableLayoutPanel.Controls.Add(CourseComboBox, 1, 0);
            tableLayoutPanel.Controls.Add(GroupsComboBox, 2, 0);
            tableLayoutPanel.Controls.Add(AlarmLabel, 3, 0);
            tableLayoutPanel.Controls.Add(groupShedule, 0, 1);
            tableLayoutPanel.SetColumnSpan(groupShedule, 4);

            groupShedule.CellDoubleClick += GroupShedule_DoubleClick;

            Controls.Add(tableLayoutPanel);
            
            this.Size = new Size(800, 600);

            if (Application.OpenForms.Count == 0) Application.Exit();
            this.Load += ScheduleForm_Load;
        }

        private void GroupShedule_DoubleClick( object sender, DataGridViewCellEventArgs e)
        {
            if (!isAdmin) return;
            var value = groupShedule[e.ColumnIndex, e.RowIndex].Value as Lesson;
            var groupName = GroupsComboBox.SelectedText;
            ChangeLessonForm changeLessonForm = new ChangeLessonForm(value, groupName , e.RowIndex+1);
            changeLessonForm.Show();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            facultyComboBox.DataSource = university.Faculties.Select(faculty => faculty.Name).ToList();

            foreach (DataGridViewRow row in groupShedule.Rows)
            {
                row.HeaderCell.Value = $"{row.Index + 1}";
            }
        }

        private void GroupsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var fac = university.Faculties.Find(faculty => faculty.Name == facultyComboBox.SelectedItem.ToString());
            var group = fac.GetFacultyGroups().Find(gr => gr.Name == GroupsComboBox.SelectedItem.ToString());
            var shedule = university.UniversitySchedule.GetGroupSchedule(group);
            FillShedule(shedule);
        }

        private void CourseComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var fac = university.Faculties.Find(faculty => faculty.Name == facultyComboBox.SelectedItem.ToString());
            var facGr = fac.GetFacultyGroups();
            var temp = facGr.Where(group => group.Course == Convert.ToInt32(CourseComboBox.SelectedItem)).ToList();
            GroupsComboBox.DataSource = temp.Select(name => name.Name).ToList();
        }

        private void FacultyComboBoxOnSelectionChangeCommitted(object sender, EventArgs eventArgs)
        {
            var temp = university.Faculties[facultyComboBox.SelectedIndex];
            CourseComboBox.DataSource = temp.GetExistingCourses();
        }

        private void FillShedule(List<Lesson> lessons)
        {
            ClearSchedule(groupShedule);
            AlarmLabel.Visible = lessons.Count == 0;
            foreach (var lesson in lessons)
            {
                var day = lesson.Day;
                var number = lesson.PairNumber;
                groupShedule[day, number].Value =  lesson;
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
    }
}
