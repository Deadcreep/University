using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    [Serializable]
    public class User
    {
        public string Name { get;  set; }
        public string Login { get;  set; }
        public string PasswordHash { get;  set; }
        public bool IsAdmin { get;  set; } 
        
        //public void ChangePassword(string newPass)
        //{
        //    if(HashPassword == newPass)
        //    {
        //        throw new ArgumentException("Новый пароль совпадает со старым");
        //    }

        //    HashPassword = newPass;
        //}
        public override string ToString()
        {
            return Login + " " + Name + " " + PasswordHash + " " + IsAdmin;
        }

    }
}
