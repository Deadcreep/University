using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]

    public class Schedule
    {
        public event EventHandler<LessonEventArgs> LessonAdded;

        private void OnLessonAdded(LessonEventArgs e)
        {
            var handler = this.LessonAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private static Schedule schedule = null;

        public List<Lesson> ScheduleList { get;  set; }

        public static Schedule ScheduleInstance => schedule ?? (schedule = ScheduleSerializator.DeserializeSchedule());

        private Schedule()
        {
        }

        public void AddLesson(Lesson newLesson)
        {
            var validationResult = ValidateLesson(newLesson);
            if (validationResult.Success == false)
            {
                throw new InvalidOperationException(validationResult.ErrorMessage);
            }

            ScheduleList.Add(newLesson);
            OnLessonAdded(new LessonEventArgs(newLesson));
        }
        
        public ValidationResult ValidateLesson(Lesson newLesson)
        {
            if (ScheduleList.Any(lesson => lesson.PairNumber == newLesson.PairNumber &&
                                           lesson.Day == newLesson.Day &&
                                           lesson.Group.Equals(newLesson.Group) &&
                                           lesson.Subject != newLesson.Subject))
            {
                return new ValidationResult() { ErrorMessage = "This group has an lesson at this time", Success = false};
            }

            if (ScheduleList.Any(lesson => lesson.PairNumber == newLesson.PairNumber &&
                                           lesson.Day == newLesson.Day &&
                                           lesson.LectureRoom.Equals(newLesson.LectureRoom) &&
                                           !lesson.Group.Equals(newLesson.Group) &&
                                           lesson.Subject != newLesson.Subject))
            {
                return new ValidationResult() {ErrorMessage = "The lecture room is busy", Success = false};
            }

            if (ScheduleList.Any(lesson => lesson.Day == newLesson.Day &&
                                           lesson.PairNumber == newLesson.PairNumber &&
                                           !lesson.LectureRoom.Equals(newLesson.LectureRoom) &&
                                           lesson.Teacher.Equals(newLesson.Teacher)))
            {
                return new ValidationResult() { ErrorMessage = "The teacher is busy", Success = false};
            }

            return new ValidationResult() {Success = true};
        }

        public List<Lesson> GetGroupSchedule(Group ggroup)
        {
            var temp = ScheduleList.Where(x => x.Group.Name == ggroup.Name).ToList();
            return temp;
        }

        public List<Lesson> GetTeacherSchedule(Teacher teacher)
        {
            var temp = ScheduleList.Where(x => x.Teacher == teacher).ToList();
            return temp;
        }

        public List<Lesson> GetEdDiSchedule(EducationDirection educationDirection)
        {
            var temp = ScheduleList.Where(x => educationDirection.Groups.Contains(x.Group)).ToList();
            return temp;
        }

        public List<Lesson> GetFacultySchedule(Faculty faculty)
        {
            var groups = faculty.EducationDirection.SelectMany(x => x.Groups).Distinct().ToList();
            var temp = ScheduleList.Where(x => groups.Contains(x.Group)).ToList();
            return temp;
        }

        public List<Lesson> GetLessonInOneDay(string day)
        {
            var temp = ScheduleList.Where(x => x.Day == day).ToList();
            return temp;
        }
    }

    public class LessonEventArgs : EventArgs
    {
        public LessonEventArgs(Lesson lesson)
        {
            Lesson = lesson;
        }
        public Lesson Lesson { get; set; }
    }
};