using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class UserList
    {

        public static Dictionary<string, User> ListOfUser = new Dictionary<string, User>();

        public void AddUser(string login, string name, string pass, bool control)
        {
            ListOfUser.Add(login, new User(name, pass, control));
        }

        public void RemoveUser(string login)
        {
            ListOfUser.Remove(login);
        }

        public static User CheckLogin(string login, string password)
        {
            if ((login != null) & (password != null) & (ListOfUser.ContainsKey(login)) &
                (ListOfUser[login].Password == password))
            {
                return ListOfUser[login];
            }
            else throw new ArgumentException("Wrong login or password");
        }

    }
}

