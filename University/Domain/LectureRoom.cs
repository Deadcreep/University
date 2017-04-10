using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]
    public class LectureRoom
    {
        public string Number { get;  set; }
        public string Type { get;  set; }

        public LectureRoom()
        {   
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
