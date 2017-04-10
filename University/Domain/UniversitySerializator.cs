using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace University
{
    public static class UniversitySerializator
    {
        public static University DeserializeUniversity()
        {
            var formatter = new XmlSerializer(typeof(University));
            FileStream fsd = new FileStream("University.xml", FileMode.OpenOrCreate);
            XmlReader reader = XmlReader.Create(fsd);
            var univer = (University) formatter.Deserialize(reader);
            fsd.Close();
            return univer;
        }

        public static void SerializeUniversity(University u)
        {
            File.Delete("University.xml");
            var formatter = new XmlSerializer(typeof(University));
            FileStream fs = new FileStream("University.xml", FileMode.OpenOrCreate);
            formatter.Serialize(fs, u);
            fs.Close();
        }

        public static University CreateUniversity()
        {
            var univer = new University() {Name = "CSU"};
            var hous1 = new Housing() {address = "Kashirin brothers 129", number = 1};
            var hous2 = new Housing() {address = "Molodogvardeytsev, 79", number = 2};

            var a15 = new LectureRoom() {Number = "A-15"};
            var a17 = new LectureRoom() {Number = "A-17"};
            var a18 = new LectureRoom() {Number = "A-18"};
            var a25 = new LectureRoom() {Number = "A-25"};
            var a20 = new LectureRoom() {Number = "A-20"};
            var a23 = new LectureRoom() {Number = "A-23"};

            var iit = new Faculty() {Name = "IIT"};
            var bio = new Faculty() {Name = "Biological"};

            var ivt = new EducationDirection() {Name = "IVT"};
            var bioE = new EducationDirection() {Name = "Ecology"};

            var teacher1 = new Teacher() {Name = "Kerensky"};
            var teacher2 = new Teacher() {Name = "Levin"};
            var teacher3 = new Teacher() {Name = "Maskin"};

            var gr1 = new Group() {Name = "IVT-103"};
            var gr2 = new Group() {Name = "IVT-100"};
            var gr3 = new Group() {Name = "BB-103"};
            var gr4 = new Group() {Name = "BB-100"};


            var practice1 = new Lesson()
            {
                Day = "Monday",
                Group = gr1,
                Teacher = teacher1,
                Subject = "Matan",
                PairNumber = 1,
                LectureRoom = a15
            };
            var practice2 = new Lesson()
            {
                Day = "Monday",
                Group = gr2,
                Teacher = teacher2,
                Subject = "Economy",
                PairNumber = 1,
                LectureRoom = a17
            };

            var shed1 = new Schedule();

            hous1.AddAuditory(a15);
            hous1.AddAuditory(a17);
            hous1.AddAuditory(a18);
            hous1.AddAuditory(a20);
            hous1.AddAuditory(a23);
            hous1.AddAuditory(a25);

            univer.AddHousing(hous1);
            univer.AddHousing(hous2);

            univer.AddTeacher(teacher1);
            univer.AddTeacher(teacher2);
            univer.AddTeacher(teacher3);

            gr2.InctrementCourse();
            gr2.InctrementCourse();
            gr3.InctrementCourse();

            ivt.AddGroup(new Group() {Name = "IVT-107"});
            ivt.AddGroup(gr1);
            ivt.AddGroup(gr2);

            bioE.AddGroup(gr3);
            bioE.AddGroup(gr4);

            iit.AddEducationDirection(ivt);
            bio.AddEducationDirection(bioE);

            shed1.AddLesson(practice1);
            shed1.AddLesson(practice2);

            univer.AddFaculty(iit);
            univer.AddFaculty(bio);
            univer.AddSchedule(shed1);

            return univer;
        }
    }
}

