using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public static class UniversityCreator
    {
        public static University CreateUniversity()
        {
            var univer = new University("CSU");
            var hous1 = new Housing("Kashirin brothers 129", 1);
            var hous2 = new Housing("Molodogvardeytsev, 79", 2);

            var a15 = new Auditory("A-15");
            var p132 = new Auditory("132");
            var q115 = new Auditory("115");
            var p315 = new Auditory("315");

            var iit = new Faculty("IIT");
            var bio = new Faculty("Biological");

            var ivt = new EducationDirection("IVT");
            var bioE = new EducationDirection("Bioo");

            var teacher1 = new Teacher("Kharn");
            var teacher2 = new Teacher("Tzeench");
            var teacher3 = new Teacher("Slaanesh");

            var gr1 = new Group("IVT-103");
            var gr2 = new Group("IVT-305");
            var gr3 = new Group("BB-101");
            var gr4 = new Group("BB-101");


            var practice1 = new Lesson("English", "Monday", p132, teacher1, gr1, 1);
            var les1 = new Lesson("Matan", "Monday", a15, teacher2, gr1, 2);
            var les2 = new Lesson("Biologie", "Monday", a15, teacher3, gr3, 2);

            var shed1 = new Schedule();

            hous1.AddAuditory(a15);
            hous1.AddAuditory(p132);
            hous2.AddAuditory(q115);
            hous2.AddAuditory(p315);

            univer.AddHousing(hous1);
            univer.AddHousing(hous2);

            univer.AddTeacher(teacher1);
            univer.AddTeacher(teacher2);
            univer.AddTeacher(teacher3);

            gr2.InctrementCourse();
            gr2.InctrementCourse();
            gr3.InctrementCourse();
        
            ivt.AddGroup(new Group("IVT-201"));
            ivt.AddGroup(gr1);
            ivt.AddGroup(gr2);

            bioE.AddGroup(gr3);
            bioE.AddGroup(gr4);

            iit.AddEducationDirection(ivt);
            bio.AddEducationDirection(bioE);

            shed1.AddLesson(les1);
            shed1.AddLesson(les2);
            shed1.AddLesson(practice1);

            univer.AddFaculty(iit);
            univer.AddFaculty(bio);
            univer.AddSchedule(shed1);

            return univer;
        }
    }
}
