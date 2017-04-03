using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace University
{
    public class Group
    {
        public string Name { get; private set; }       
        public int Course { get; private set; }

        public Group(string name)
        {
            Name = name;
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
    }
}
