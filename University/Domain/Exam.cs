using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Exam : Lesson 
    {
       public DateTime time { get; private set; }

        public Exam(DateTime dt, string subject, string day, string aud, Teacher teacher, Group group) : base(subject, day, aud, teacher, group)
        {
            time = dt;
        }
    }
}
