using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]
    public class Housing
    {
        public List<LectureRoom> LectureRooms { get;  set; }
        public string address;
        public int number;

        public Housing()
        {
            LectureRooms = new List<LectureRoom>();
        }

        public void AddAuditory(LectureRoom a)
        {
            LectureRooms.Add(a);
        }
    }

}
