using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Authorization
    {
        public event EventHandler<AuthorizationEventArgs> TryLogin;

        public void TryLogin_Click(LoginForm sender, EventArgs e)
        {
            //sender.Hide();
            //if ()
            //    var mainmenu = new MainMenu();
            //mainmenu.Show();
        }
    }
}
