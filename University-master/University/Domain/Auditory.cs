using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Auditory
    {
        public string Number { get; private set; }
        public string Type { get; private set; }

        public Auditory(string number, string type)
        {
            Number = number;
            Type = type;
        }
    }
}
