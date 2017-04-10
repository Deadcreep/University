using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]
    public class Teacher
    {
        public string Name { get;  set; }
        public List<string> Subjects { get;  set; }

        public Teacher()
        {
            Subjects = new List<string>();            
        }

        public void AddSubject (string subject)
        {
            Subjects.Add(subject);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
