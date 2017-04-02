using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class User
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public bool Control { get; private set; } // if true - can change shedule

        public User(string name, string password, bool control)
        {
            Name = name;
            Password = password;
            Control = control;
        }

        public void ChangePassword(string newPass)
        {
            if(Password == newPass)
            {
                throw new ArgumentException("Новый пароль совпадает со старым");
            }

            Password = newPass;
        }

        public override string ToString()
        {
            return Name + " " + Password + " " + Control;
        }

    }
}
