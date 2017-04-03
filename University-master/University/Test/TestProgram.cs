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
            University univer = new University("CSU");
            Housing Hous1 = new Housing("Kashirin brothers 129", 1);
            Hous1.AddAuditory(new Auditory("A-15", "Lecture room"));
            Hous1.AddAuditory(new Auditory("132", "Practical room"));
 
            Housing Hous2 = new Housing("Molodogvardeytsev, 79", 2);
            Hous2.AddAuditory(new Auditory("115", "Lecture room"));
            Hous2.AddAuditory(new Auditory("315", "Practical room"));
           
            univer.AddHousing(Hous1);
            univer.AddHousing(Hous2);

            

            Faculty Iit = new Faculty("IIT");
            Console.WriteLine(Iit.Name);
            EducationDirection Ivt = new EducationDirection("IVT");
            Ivt.AddGroup(new Group("IVT-201"));
            
            Group gr1 = new Group("IVT-103");
            Console.WriteLine(gr1.Name);
            gr1.InctrementCourse();
            Console.WriteLine(gr1.Name);


            UserList TestList = new UserList() { ListOfUser = Reader.GetUserList("UserListExample.txt") };
            foreach( var temp in TestList.ListOfUser)
            {
                Console.WriteLine(temp.Key + " " +  temp.Value.ToString());                
            }
            Console.ReadLine();
        }
    }
}
