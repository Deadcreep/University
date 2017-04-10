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
        private University university; 
        private readonly string[] SubjectArray = new[]
        {
            "Mathematics", "English", "German", "Chemistry", "Economy", "Philosophy", "Programming", "Informatics",
            "History"
        };
        
        private ComboBox subjectComboBox;
        private ComboBox LectureRoomComboBox;
        private ComboBox dayComboBox;
        private ComboBox teacherComboBox;
        private ComboBox numberComboBox;
        private ComboBox groupComboBox;
        private Label infoLabel;
        

        public ChangeLessonForm(Lesson lesson)
        {
            this.lesson = lesson;
            var university = UniversitySerializator.DeserializeUniversity();

            infoLabel = new Label()
            {
                Size = new Size(150, 20),
                Location = new Point(0, 0),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                Text = lesson.Day + "       Pair number: " + lesson.PairNumber,
                Dock = DockStyle.Fill,
            };

            subjectComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Location = new Point(0, infoLabel.Bottom + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = SubjectArray,
                Dock = DockStyle.Fill,
            };

            LectureRoomComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Location = new Point(0, subjectComboBox.Bottom + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = university.Housings.SelectMany(housing => housing.LectureRooms).ToList(),
                Dock = DockStyle.Fill,
            };

            teacherComboBox = new ComboBox()
            {
                Size = new Size(130, 50),
                Location = new Point(0, LectureRoomComboBox.Bottom + 10),
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = university.Teachers,
                Dock = DockStyle.Fill,
            };

            Button createLesson = new Button()
            {
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                Size = new Size(70, 30),
                Text = "Create lesson",
                Dock = DockStyle.Fill,
            };

            var cancelButton = new Button()
            {
                Anchor = AnchorStyles.Top & AnchorStyles.Left,
                Size = new Size(70, 30),
                Text = "Cancel",
                Dock = DockStyle.Fill,
            };

            AcceptButton = createLesson;
            CancelButton = cancelButton;

            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            table.Controls.Add(infoLabel, 0, 0);
            table.Controls.Add(subjectComboBox, 0, 1);
            table.Controls.Add(LectureRoomComboBox, 0, 2);
            table.Controls.Add(teacherComboBox, 0, 3);
            table.Controls.Add(createLesson, 0, 4);
            table.Controls.Add(cancelButton, 0, 5);
            Controls.Add(table);

            cancelButton.Click += CancelButton_Click;

            createLesson.Click += CreateLesson_Click;
            
        }

        private void CreateLesson_Click(object sender, EventArgs e)
        {
            lesson.LectureRoom = LectureRoomComboBox.SelectedItem as LectureRoom;
            lesson.Teacher = teacherComboBox.SelectedItem as Teacher;
            lesson.Subject = subjectComboBox.SelectedItem as string;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
