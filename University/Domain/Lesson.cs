using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]
    public class Lesson
    {
        public string Subject { get;  set; }
        public string Day { get;  set; }
        public LectureRoom LectureRoom { get;  set; }
        public Teacher Teacher { get;  set; }
        public  Group Group { get;  set; }
        public int PairNumber { get;  set; }

        public Lesson()
        {
           
        }

        public override string ToString()
        {   
            return Subject + " Aud. " + LectureRoom.Number + " " + Teacher.Name;
        }
    }
}
