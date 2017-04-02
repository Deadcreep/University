using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace University
{
    public static class Reader
    {
        static public Dictionary<string, User> GetUserList(string filename)
        {
            var usersInfo = File.ReadAllLines(filename);
            Dictionary<string, User> userList = new Dictionary<string, User>();

            for (int i = 0; i < usersInfo.Length; ++i)
            {
                try
                {
                    var userInfo = usersInfo[i].Split();
                    userList.Add(userInfo[0], new User(userInfo[1],
                                                       userInfo[2], 
                                                       Convert.ToBoolean(userInfo[3])));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Argument exception at line {0} : {1}", i, ae);
                }
            }           

            return userList;
        }       
    }
}
