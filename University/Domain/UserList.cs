using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class UserList
    {
        public Dictionary<string, User> ListOfUser;

        public void AddUser(string login, string name, string pass, bool control)
        {
            ListOfUser.Add(login, new User(name, pass, control));
        }

        public void RemoveUser(string login)
        {
            ListOfUser.Remove(login);
        }


    }
}
