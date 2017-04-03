using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserList userlist = new UserList()
            {
                ListOfUser = new Dictionary<string, User>()
                                                            {
                                                                { "throll", new User("Andrew", "123", true)},
                                                                { "LordOfChaos", new User ("Andrew", "666Hell666", false)},
                                                                { "Helen67", new User ("Helen", "9ijn*UHB", true) },
                                                                { "log123", new User ("Alex", "123ert456", true) },
                                                                { "GreenDog", new User ("John", "qwerty", false) }
                                                            }
            };

            Application.Run(new LoginForm());
        }
    }
}
    