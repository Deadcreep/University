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
    
    public class Membership
    {
        [XmlArrayItem("MemberList"), XmlArrayItem("Item")]
        public static List<User> MemberList = DeserializeMembership();

        public static string GetPasswordHash(string value)
        {
            Encoding encoding = Encoding.ASCII;
            byte[] bytes = encoding.GetBytes(value);

            return Convert.ToBase64String(bytes);
        }
       
        private static string GetString(string base64)
        {
            Encoding encoding = Encoding.ASCII;
            var bytes = Convert.FromBase64String(base64);

            return encoding.GetString(bytes);
        }

        public static List<User> DeserializeMembership()
        {
            var formatter = new XmlSerializer(typeof(List<User>));
            FileStream fsdm = new FileStream("Membership.xml", FileMode.OpenOrCreate);
            XmlReader reader = XmlReader.Create(fsdm);
            var membership = (List<User>)formatter.Deserialize(reader);
            fsdm.Close();
            return membership;
        }

        public static void SerializeMembership(List<User> m)
        {
            File.Delete("Membership.xml");
            var formatter = new XmlSerializer(typeof(List<User>));
            FileStream fsm = new FileStream("Membership.xml", FileMode.OpenOrCreate);
            formatter.Serialize(fsm, m);
            fsm.Close();
        }
        
        public void AddUser(string login, string name, string pass, bool control)
        {
            MemberList.Add( new User() {Login = login,Name = name, PasswordHash = GetPasswordHash(pass), IsAdmin = control });
            SerializeMembership(MemberList);
        }

        public void RemoveUser(string login)
        {
            MemberList.Remove(MemberList.Find(user => user.Login == login));
        }

        public static User CheckLogin(string login, string password)
        {
            if ((login != null) & (password != null) & (MemberList.Any(user => user.Login == login)) &
                (MemberList.Any(user => user.Login == login && user.PasswordHash == GetPasswordHash(password))))
            {
                return MemberList.Find(user => user.Login == login);
            }
            else throw new ArgumentException("Wrong login or password");
        }

    }
}

