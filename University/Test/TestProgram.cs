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
            var univer = new University("CSU");

            var hous1 = new Housing("Kashirin brothers 129", 1); 
            var a15 = new Auditory("A-15", "Lecture room"); 
            var p132 = new Auditory("132", "Practical room"); 
            hous1.AddAuditory(a15);
            hous1.AddAuditory(p132);

            var hous2 = new Housing("Molodogvardeytsev, 79", 2);
            var q115 = new Auditory("115", "Lecture room");
            var p315 = new Auditory("315", "Practical room");
            hous2.AddAuditory(q115);
            hous2.AddAuditory(p315);

            univer.AddHousing(hous1);
            univer.AddHousing(hous2);

            var iit = new Faculty("IIT");

            var ivt = new EducationDirection("IVT");
            ivt.AddGroup(new Group("IVT-201"));

            var teach1 = new Teacher("Kharn");

            var gr1 = new Group("IVT-103");
            var gr2 = new Group("IVT-305");
            ivt.AddGroup(gr1);
            ivt.AddGroup(gr2);

            var practice1 = new Practice(1, "Matan", "Monday", p132, teach1, gr1);
            var les1 = new Lection(2, "Matan", "Monday", a15, teach1, gr1);
            var shed1 = new Shedule();
            shed1.AddLesson(les1);
            shed1.AddLesson(les1);
            shed1.AddLesson(practice1);

            var temp1 = shed1.GetGroupShedule(gr1);
            var temp2 = shed1.GetTeacherShedule(teach1);
            var temp3 = shed1.GetEdDiShedule(ivt);
            Console.WriteLine(temp3.Count + " " + temp3[0].Subject );

            var testList = new UserList() { ListOfUser = Reader.GetUserList("UserListExample.txt") };
            foreach( var temp in testList.ListOfUser)
            {
                Console.WriteLine(temp.Key + " " +  temp.Value.ToString());                
            }
            
        }
    }
}
