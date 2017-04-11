using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]
    public class University
    {
        private static University university;
        public string Name { get;  set; }
        public List<Faculty> Faculties { get;  set; }
        public List<Housing> Housings { get;  set; }
        public List<Teacher> Teachers { get;  set; }

        public static University UniversityInstance => university ??
                                                       (university = UniversitySerializator.DeserializeUniversity());

        private University()
        {
            Faculties = new List<Faculty>();
            Housings = new List<Housing>();
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

        public string[] GetFacultyNameslList()
        {
            var temp = Faculties.Select(faculty => faculty.Name).ToArray();
            return temp;
        }
    }
}
