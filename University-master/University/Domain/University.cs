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

        public University(string name)
        {
            Name = name;
            Faculties = new List<Faculty>();
            Housings = new List<Housing>();
        }

        public void AddFaculty (Faculty faculty)
        {
            Faculties.Add(faculty);
        }

        public void AddHousing (Housing housing)
        {
            Housings.Add(housing);
        }
    }
}
