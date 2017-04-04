using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University
{
    class SheduleModel 
    {
        private readonly Shedule _shedule;

        public SheduleModel(Shedule shed)
        {
            _shedule = shed;
        }

        public Group GetGroup()
        {
            return _shedule.GroupShedule[0].Group;
        }

        public List<Lesson> GetLessonInOneDay(string day)
        {
            var temp = new List<Lesson>();
            foreach (var ftemp in temp)
            {
                if (ftemp.Day == day)
                {
                    temp.Add(ftemp);
                }
            }
            return temp;
        }
    }
}
