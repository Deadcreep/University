using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]
    public class EducationDirection
    {
        public string Name { get;  set; }
        public List<Group> Groups { get;  set; }

        public EducationDirection()
        {
            Groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }                
    }
}
