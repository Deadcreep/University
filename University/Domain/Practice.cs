using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Practice : Lesson
    {
        public int PairNumber { get; private set; }

        public Practice(int num, string subject, string day, string aud, Teacher teacher) : base(subject, day, aud, teacher)
        {
            PairNumber = num;
        }
    }
}
