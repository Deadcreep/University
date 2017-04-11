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
       
        public LectureRoom()
        {   
        }

        public override string ToString()
        {
            return Number;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as LectureRoom;
            if (temp == null) return false;
            if (temp == this) return true;
            return this.Number == temp.Number;
        }
    }
}
