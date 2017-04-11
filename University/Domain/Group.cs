using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace University
{
    [Serializable]
    public class Group
    {
        public string Name { get;  set; }       
        public int Course { get;  set; }

        public Group()
        {  
            Course = 1;
        }

        public void InctrementCourse()
        {
            Course++;
            StringBuilder temp = new StringBuilder(Name);
            Regex tmp = new Regex(@"\d");
            Match matchTemp = tmp.Match(Name);
            var intemp =  Name.IndexOf(Convert.ToChar(matchTemp.Value));            
            temp[intemp]++;
            Name = Convert.ToString(temp);           
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Group;
            if (temp == null) return false;
            if (temp == this) return true;
            return this.Name == temp.Name;
        }
    }
}
