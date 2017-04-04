using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class EducationDirection
    {
        public string Name { get; private set; }
        public List<Group> Groups { get; private set; }

        public EducationDirection(string name)
        {
            Name = name;
            Groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }                
    }
}
