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
        //[STAThread]
        static void Main()
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

            Console.WriteLine(univer.Name);            

            Faculty Iit = new Faculty("IIT");
            Console.WriteLine(Iit.Name);
            EducationDirection Ivt = new EducationDirection("IVT");
            Ivt.AddGroup(new Group("IVT-201"));

            Group gr1 = new Group("IVT-103");
            Console.WriteLine(gr1.Name);
            gr1.InctrementCourse();
            Console.WriteLine(gr1.Name);

            Teacher teacher = new Teacher("Андрей Петров");
            teacher.AddSubject("ФИзра");
            Console.WriteLine(teacher.Name);
            Lesson lesson1 = new Lesson("Английский", "Суббота", "123", teacher, gr1);
            Shedule shed1 = new Shedule(lesson1);
            //Console.WriteLine(shed1.GetSheudule(gr1));

            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainMenu login = new MainMenu();
            Application.Run(login);
            login.onClick += shed1.GetSheudule;
        }
    }
}
