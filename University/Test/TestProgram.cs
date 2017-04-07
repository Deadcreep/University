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
            univer.AddFaculty(iit);
            var gr1 = new Group("IVT-103");
            var gr2 = new Group("IVT-305");
            gr2.InctrementCourse();
            gr2.InctrementCourse();
            ivt.AddGroup(gr1);
            ivt.AddGroup(gr2);
            iit.AddEducationDirection(ivt);
            var practice1 = new Lesson("Matan", "Monday", p132, teach1, gr1, 1);
            var les1 = new Lesson("English", "Monday", a15, teach1, gr1, 2);
            var shed1 = new Schedule();
            shed1.AddLesson(les1);
            shed1.AddLesson(les1);
            shed1.AddLesson(practice1);

            var temp5 = iit.GetGroupsOfCourse(1);
            var temp6 = iit.GetFacultyGroups();

            Console.WriteLine(temp6.Count + " " + temp6.First().Name + " " + temp6.Last().Name);

            var temp1 = shed1.GetGroupSchedule(gr1);
            var temp2 = shed1.GetTeacherSchedule(teach1);
            var temp3 = shed1.GetEdDiSchedule(ivt);
            var temp4 = iit.GetMaxCourse();
            Console.WriteLine(temp4);
            var testList = new UserList();
            testList.AddUser("Max", "Maxim", "qwerty", true);
            testList.AddUser("Dajan", "Dajan", "qwerty", true);
            testList.AddUser("Petro", "Petro", "qwerty", true);
            testList.AddUser("Sanya", "Sanya", "qwerty", true);
            
        }
    }
}
