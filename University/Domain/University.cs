using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    
    public class University
    {
        public string Name { get; private set; }
        public List<Faculty> Faculties { get; private set; }
        public List<Housing> Housings { get; private set; }
        public Schedule UniversitySchedule { get; private set; }
        public List<Teacher> Teachers { get; private set; }

        public University(string name)
        {
            Name = name;
            Faculties = new List<Faculty>();
            Housings = new List<Housing>();
            UniversitySchedule = new Schedule();
            Teachers = new List<Teacher>();
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
        
        public void AddFaculty (Faculty faculty)
        {
            Faculties.Add(faculty);
        }

        public void AddHousing (Housing housing)
        {
            Housings.Add(housing);
        }

        public void AddSchedule(Schedule schedule)
        {
            UniversitySchedule = schedule;
        }

        public string[] GetFacultyNameslList()
        {
            var temp = Faculties.Select(faculty => faculty.Name).ToArray();
            return temp;
        }
    }
}
