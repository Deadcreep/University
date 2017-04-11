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
    [Serializable]
    public class Membership
    {
        private static Membership myMembership;
        public List<User> UserList;
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

        private Membership()
        {
            UserList = new List<User>()
            {
                new User() {Login = "Max",Name = "Maxim", PasswordHash = Membership.GetPasswordHash("qwerty"), IsAdmin = true},
                new User() {Login = "Dajan",Name = "Dajan",PasswordHash = Membership.GetPasswordHash("qwerty"),IsAdmin = true},
                new User() {Login = "Petro",Name = "Petro",PasswordHash = Membership.GetPasswordHash("qwerty"),IsAdmin = false},
            };
        }

        public static Membership MyMembership => myMembership ?? (myMembership = new Membership());

        public void AddUser(string login, string name, string pass, bool control)
        {
            myMembership.UserList.Add( new User() {Login = login,Name = name, PasswordHash = GetPasswordHash(pass), IsAdmin = control });
            MembershipSerializator.SerializeMembership(this);
        }

        public void RemoveUser(string login)
        {
            UserList.Remove(UserList.Find(user => user.Login == login));
        }

        public static User CheckLogin(string login, string password)
        {
            if ((login != null) & (password != null) & (MyMembership.UserList.Any(user => user.Login == login)) &
                (MyMembership.UserList.Any(user => user.Login == login && user.PasswordHash == GetPasswordHash(password))))
            {
                return MyMembership.UserList.Find(user => user.Login == login);
            }
            else throw new ArgumentException("Wrong login or password");
        }

    }
}

