using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University;

namespace University
{
    

    class TestProgram
    {
        
        static void Main(string[] args)
        {
            University univer = new University();

            UserList TestList = new UserList() { ListOfUser = Reader.GetUserList("UserListExample.txt") };
            foreach( var temp in TestList.ListOfUser)
            {
                Console.WriteLine(temp.Key + " " +  temp.Value.ToString());
            }
            
        }
    }
}
