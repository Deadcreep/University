using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]
    public class Teacher
    {
        public string Name { get;  set; }
        
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Teacher;
            if (temp == null) return false;
            if (temp == this) return true;
            return this.Name == temp.Name;
        }
    }
}
