using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using University;

namespace University
{


    class TestProgram
    {static void Main(string[] args)
        {
            try
            {
                //var testList = new Membership();
                //testList.AddUser("Max", "Maxim", "qwerty", true);
                //testList.AddUser("Dajan", "Dajan", "qwerty", true);
                //testList.AddUser("Petro", "Petro", "qwerty", true);
                //testList.AddUser("Sanya", "Sanya", "qwerty", false);

                var testList = new List<User>()
                {
                    new User() {Login = "Max",Name = "Maxim", PasswordHash = Membership.GetPasswordHash("qwerty"), IsAdmin = true},
                    new User() {Login = "Dajan",Name = "Dajan",PasswordHash = Membership.GetPasswordHash("qwerty"),IsAdmin = true},
                    new User() {Login = "Petro",Name = "Petro",PasswordHash = Membership.GetPasswordHash("qwerty"),IsAdmin = false},
                };

                Membership.SerializeMembership(testList);
                var temp = Membership.DeserializeMembership();
                var membership = new Membership();
                membership.AddUser("q", "w", "as12", true);
                Membership.SerializeMembership(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}

