using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace University
{
    public static class MembershipSerializator
    {
        public static Membership DeserializeMembership()
        {
            var formatter = new XmlSerializer(typeof(Membership));
            FileStream fsdm = new FileStream("Membership.xml", FileMode.Open);
            XmlReader reader = XmlReader.Create(fsdm);
            var membership = (Membership) formatter.Deserialize(reader);
            reader.Close();
            fsdm.Close();
            return membership;
        }

        public static void SerializeMembership(Membership m)
        {
            File.Delete("Membership.xml");
            var formatter = new XmlSerializer(typeof(Membership));
            FileStream fsm = new FileStream("Membership.xml", FileMode.Create);
            formatter.Serialize(fsm, m);
            fsm.Close();
        }

    }
}
