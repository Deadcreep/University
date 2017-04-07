using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Lesson
    {
        public string Subject { get; private set; }
        public string Day { get; private set; }
        public Auditory Auditory { get; private set; }
        public Teacher Teacher { get; private set; }
        public  Group Group { get; private set; }
        public int PairNumber { get; private set; }

        public Lesson(string subject, string day, Auditory aud, Teacher teacher, Group @group, int pairnum)
        {
            Subject = subject;
            Day = day;
            Auditory = aud;
            Teacher = teacher;
            Group = @group;
            PairNumber = pairnum;
        }

        public override string ToString()
        {   
            return Subject + " Aud. " + Auditory.Number + " " + Teacher.Name;
        }
    }
}
