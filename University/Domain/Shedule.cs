using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Shedule
    {
        public List<Lesson> GroupShedule { get; private set; }

        public void AddLesson(Lesson less)
        {
            GroupShedule.Add(less);
        }
    }
    
    

}
