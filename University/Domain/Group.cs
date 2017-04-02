using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Group
    {
        public string Name { get; private set; }       
        public int Course { get; private set; }

        public Group(string name)
        {
            Name = name;
            Course = 1;
        }

        public void InctrementCourse()
        {
            Course++;
        }
    }
}
