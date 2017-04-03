using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class AuthorizationEventArgs : EventArgs
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public AuthorizationEventArgs(string log, string pass)
        {
            Login = log;
            Password = pass;
        }
    }
}
