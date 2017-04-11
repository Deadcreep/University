using System;
using System.Collections.Generic;
using System.IO;
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
            var temp = Membership.MyMembership;
            temp.AddUser("q", "n", "qw12", true);
            //var testList = new Membership();
            //testList.AddUser("Max", "Maxim", "qwerty", true);
            //testList.AddUser("Dajan", "Dajan", "qwerty", true);
            //testList.AddUser("Petro", "Petro", "qwerty", true);
            //testList.AddUser("Sanya", "Sanya", "qwerty", false);
        //    var uni = UniversityCreator.CreateUniversity();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login = new LoginForm();
            //ChangeLessonForm tst = new ChangeLessonForm(test.UniversitySchedule.ScheduleList.First());
             ScheduleForm sheduleForm = new ScheduleForm(true);
            Application.Run(login);
        }
    }
}
    