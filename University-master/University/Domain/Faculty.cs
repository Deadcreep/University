using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
