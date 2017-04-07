using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Schedule
    {
        public List<Lesson> ScheduleList { get; private set; }

        public Schedule()
        {
            ScheduleList = new List<Lesson>();
        }

        public void AddLesson(Lesson lessons)
        {
            ScheduleList.Add(lessons);
        }

        public List<Lesson> GetGroupSchedule(Group ggroup)
        {
            var temp = ScheduleList.Where(x => x.Group == ggroup).ToList();
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