using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace University
{
    class ChangeLessonForm : Form
    {
        private Lesson lesson;
        private University university = UniversityCreator.CreateUniversity();
        private readonly string[] SubjectArray = new[]
        {
            "Mathematics", "English", "German", "Chemistry", "Economy", "Philosophy", "Programming", "Informatics",
            "History"
        };

        private readonly DayOfWeek[] dayOfWeek = new DayOfWeek[] {DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                                                         DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };

        private ComboBox subjectComboBox;
        private ComboBox auditoryComboBox;
        private ComboBox dayComboBox;
        private ComboBox teacherComboBox;
        private ComboBox numberComboBox;
        private ComboBox groupComboBox;
        private Label groupLabel;
        private Label pairLabel;
        public ChangeLessonForm(Lesson lesson,string name, int number)
        {
            this.lesson = lesson;

            groupLabel = new Label()
            {
                Size = new Size(50, 20),
                Location = new Point(0, 0),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                Text = name,
            };

            pairLabel = new Label()
            {
                Size = new Size(100, 20),
                Location = new Point(0, groupLabel.Right + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                Text = "Pair number: " + number.ToString(),
            };

            subjectComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Location = new Point(0, groupLabel.Bottom + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = SubjectArray,
            };

            dayComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Location = new Point(0, subjectComboBox.Bottom + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = dayOfWeek,
            };

            auditoryComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Location = new Point(0, dayComboBox.Bottom + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = university.Housings.SelectMany(housing => housing.Auditories).ToList(),
                Text = "Select auditory",
            };

            teacherComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Location = new Point(0, auditoryComboBox.Bottom + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = university.Teachers,
            };

            Button createLesson = new Button()
            {
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                Size = new Size(70, 30),
                Text = "Create lesson",
            };

            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            
            table.Controls.Add(groupLabel, 0, 0);
            table.Controls.Add(pairLabel, 1, 0);
            table.Controls.Add(subjectComboBox, 0, 1);
            table.Controls.Add(dayComboBox, 0, 2);
            table.Controls.Add(auditoryComboBox, 0, 3);
            table.Controls.Add(teacherComboBox, 0, 4);
            table.Controls.Add(createLesson, 0, 5);
            table.SetColumnSpan(subjectComboBox, 2);
            table.SetColumnSpan(dayComboBox, 2);
            table.SetColumnSpan(auditoryComboBox, 2);
            table.SetColumnSpan(teacherComboBox, 2);
            table.SetColumnSpan(createLesson, 2);
            Controls.Add(table);
            //Controls.Add(groupLabel);
            //Controls.Add(pairLabel);
            //Controls.Add(subjectComboBox);
            //Controls.Add(dayComboBox);
            //Controls.Add(auditoryComboBox);
            //Controls.Add(teacherComboBox);
            //Controls.Add(createLesson);
        }
    }
}
