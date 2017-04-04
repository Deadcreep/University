using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Shedule
    {
        public List<Lesson> SheduleList { get; private set; }

        public Shedule()
        {
            SheduleList = new List<Lesson>();
        }

        public void AddLesson(Lesson lessons)
        {
            SheduleList.Add(lessons);
        }

        public void AddLesson(string subject, string day, Auditory aud, Teacher teacher, Group @group)
        {
            
        }

        public List<Lesson> GetGroupShedule(Group ggroup)
        {
            var temp = SheduleList.Where(x => x.Group == ggroup).ToList();
            return temp;
        }

        public List<Lesson> GetTeacherShedule(Teacher teacher)
        {
            var temp = SheduleList.Where(x => x.Teacher == teacher).ToList();
            return temp;
        }

        public List<Lesson> GetEdDiShedule(EducationDirection educationDirection)
        {
            var temp = SheduleList.Where(x => educationDirection.Groups.Contains(x.Group)).ToList();
            return temp;
        }

        public List<Lesson> GetFacultyShedule(Faculty faculty)
        {
            var groups = faculty.EducationDirection.SelectMany(x => x.Groups).Distinct().ToList();
            var temp = SheduleList.Where(x => groups.Contains(x.Group)).ToList();
            return temp;
        }
    }
};