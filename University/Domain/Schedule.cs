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
        public List<Lesson> ScheduleList { get;  set; }

        public Schedule()
        {
            ScheduleList = new List<Lesson>();
        }

        public void AddLesson(Lesson newLesson)
        {
            if (ScheduleList.Any(lesson => lesson.PairNumber == newLesson.PairNumber &&
                                           lesson.Day == newLesson.Day &&
                                           lesson.Group == newLesson.Group &&
                                           lesson.Subject != newLesson.Subject))
    {
                throw new ArgumentException("This group has an lesson at this time");
            }

            if (ScheduleList.Any(lesson => lesson.PairNumber == newLesson.PairNumber &&
                                           lesson.Day == newLesson.Day &&
                                           lesson.LectureRoom == newLesson.LectureRoom &&
                                           lesson.Group != newLesson.Group &&
                                           lesson.Subject != newLesson.Subject))
            {
                throw new ArgumentException("The lecture room is busy");
            }

            if (ScheduleList.Any(lesson => lesson.Day == newLesson.Day &&
                                           lesson.PairNumber == newLesson.PairNumber &&
                                           lesson.LectureRoom != newLesson.LectureRoom &&
                                           lesson.Teacher == newLesson.Teacher))
            {
                throw new ArgumentException("The teacher is busy");
            }

            ScheduleList.Add(newLesson);
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
};