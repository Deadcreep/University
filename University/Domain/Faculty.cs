using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Faculty
    {
        public string Name { get; private set; }
        public List<EducationDirection> EducationDirection { get; private set; }
       

        public Faculty(string name)
        {
            Name = name;
            EducationDirection = new List<EducationDirection>();
            
        }

        public void AddEducationDirection(EducationDirection eddir)
        {
            EducationDirection.Add(eddir);
        }
        
        public List<string> GetEdDiNamesList()
        {
            var temp = EducationDirection.Select(x => x.Name).ToList();
            return temp;
        }

        public int GetMaxCourse()
        { 
            var temp = EducationDirection.Max(direction => direction.Groups.Max(group => group.Course));
            return temp;
        }

        public List<Group> GetFacultyGroups()
        {
            var temp = EducationDirection.SelectMany(direction => direction.Groups).Distinct().ToList();
            return temp;
        }

        public List<int> GetExistingCourses()
        {
            var groups = EducationDirection.SelectMany(direction => direction.Groups).Distinct().ToList();
            var temp = groups.Select(group => group.Course).Distinct().ToList();
            temp.Sort();
            return temp;
        }

        public List<Group> GetGroupsOfCourse(int course)
        {
            var groups = EducationDirection.SelectMany(direction => direction.Groups).Distinct().ToList();
            var temp = groups.Where(group => group.Course == course).ToList();
            return temp;
        }
    }
}
