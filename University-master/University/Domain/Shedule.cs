using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Shedule
    {        
      //  public List<Lesson> GroupShedule { get; private set; }
        

        public List<Lesson> GroupShedule = new List<Lesson>();
        public Shedule(Lesson lesson)
        {            
            GroupShedule.Add(lesson);
        }

        public string GetSheudule()
        {
            return GroupShedule[0].Teacher.Name;            
        }
    }
}
