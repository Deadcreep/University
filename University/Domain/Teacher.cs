using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Teacher
    {
        public string Name { get; private set; }
        public List<string> Subject { get; private set; }

        public Teacher(string name)
        {
            Name = name;
            Subject = new List<string>();            
        }

        public void AddSubject (string subject)
        {
            Subject.Add(subject);
        }
    }
}
