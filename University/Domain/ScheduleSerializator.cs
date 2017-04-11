using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace University
{
    public class ScheduleSerializator
    {
        public static Schedule DeserializeSchedule()
        {
            var formatter = new XmlSerializer(typeof(Schedule));
            FileStream fsd = new FileStream("Schedule.xml", FileMode.OpenOrCreate);
            XmlReader reader = XmlReader.Create(fsd);
            var schedule = (Schedule)formatter.Deserialize(reader);
            reader.Close();
            fsd.Close();
            return schedule;
        }

        public static void SerializeSchedule(Schedule u)
        {
            File.Delete("Schedule.xml");
            var formatter = new XmlSerializer(typeof(Schedule));
            FileStream fs = new FileStream("Schedule.xml", FileMode.OpenOrCreate);
            formatter.Serialize(fs, u);
            fs.Close();
        }
    }
}
