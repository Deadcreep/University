using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Housing
    {
        public List<Auditory> Auditories { get; private set; }
        string address;
        int number;


        public Housing(string address, int number)
        {
            this.address = address;
            this.number = number;
        }

        public void AddAuditory(Auditory a)
        {
            List<Auditory> Auditories = new List<Auditory>();
            Auditories.Add(a);
        }
    }

}
