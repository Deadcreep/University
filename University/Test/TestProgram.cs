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
                var membership = Membership.MyMembership;

                membership.AddUser("Max", "Maxim", "qwerty", true);
                membership.AddUser("Dajan", "Dajan", "qwerty", true);
                membership.AddUser("Petro", "Petro", "qwerty", true);
                membership.AddUser("Sanya", "Sanya", "qwerty", false);
                var testList = 

                MembershipSerializator.SerializeMembership(membership);
                var temp = MembershipSerializator.DeserializeMembership();
                membership.AddUser("q", "w", "as12", true);
                MembershipSerializator.SerializeMembership(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}

