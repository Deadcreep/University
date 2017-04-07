using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Practice : Lesson
    {
       // public int PairNumber { get; private set; }

        public Practice(string subject, string day, Auditory aud, Teacher teacher, Group gr, int num) : base( subject,  day,  aud,  teacher,  gr,  num)
        {
            
        }
    }
}
