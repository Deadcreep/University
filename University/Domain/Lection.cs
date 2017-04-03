using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Lection : Lesson
    {
        public int PairNumber { get; private set; }

        public Lection(int number, string subject, string day, string aud, Teacher teacher) : base(subject, day, aud, teacher)
        {
            PairNumber = number;
        }
    }
}
