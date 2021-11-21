using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Logic;
using XS3GNR_HFT_2021221.Models;
using XS3GNR_HFT_2021221.Repository;

namespace XS3GNR_HFT_2021221.Test
{
    [TestFixture]
    class StudentTest
    {
        StudentLogic sl;

        [SetUp]
        public void Init()
        {
            var mockStudRepo = new Mock<IStudentRepository>();

            University OE = new University() { Name = "Óbudai Egyetem", Id = 1, ShortName = "OE" };
            Faculty NIK = new Faculty() { Name = "Neumann János Informatikai Kar", Id = 1, UniId = OE.Id, University = OE};

            var students = new List<Student>
            {
                new Student()
                {
                     Id = 1,
                    Name = "Fehér Dominik",
                    NeptunId = "GV2OA1",
                    FacultyId = NIK.Id,
                    Faculty = NIK,
                    BirthDate = new DateTime(2002,01,02)
                },
                new Student()
                {
                    Id = 2,
                    Name = "Veres Árpád",
                    NeptunId = "QAX0PS",
                    FacultyId = NIK.Id ,
                    Faculty = NIK,
                    BirthDate = new DateTime(1998,02,04)
                }
            }.AsQueryable();

            mockStudRepo.Setup((t) => t.ReadAll())
                .Returns(students);

            sl = new StudentLogic(mockStudRepo.Object);
        }


        [Test]
        public void CreateTest()
        {
            Student stud = new Student() { Id = -200, Name = "Péter", NeptunId = "ASDASD" };

            Assert.That(() => sl.Create(stud), Throws.Exception );
        }

        [Test]
        public void ReadAllWorks()
        {
            Assert.That(() => sl.ReadAll(), Is.Not.Empty);
        }

        [Test]
        public void AvgNameLengthTest()
        {

            var result = sl.StudentAverageNameLength();

            var expected = new List<StudentsAverage>()
            {
                new StudentsAverage
                {
                    UniversityName = "Óbudai Egyetem",
                    AverageStudentNameLength = 12
                }
            };

            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        public void StudentAgeTest()
        {
            var result = sl.StudentsFromLastCentury();

            var expected = new List<StudentResult>
            {
                new StudentResult
                {
                    StudentName = "Veres Árpád",
                    StudentNeptunId ="QAX0PS",
                    StudentsUni = "Óbudai Egyetem",
                    StudentFaculty = "Neumann János Informatikai Kar",
                    BirthDate = new DateTime(1998,02,04)
                }


            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void NeptunIdTest()
        {
            var result = sl.Studentswith_X_inNeptunId();

            var expected = new List<StudentResult>
            {
                new StudentResult
                {
                    StudentName = "Veres Árpád",
                    StudentNeptunId ="QAX0PS",
                    StudentsUni = "Óbudai Egyetem",
                    StudentFaculty = "Neumann János Informatikai Kar",
                    BirthDate = new DateTime(1998,02,04)
                }
            };

            Assert.That(result, Is.EqualTo(expected));
        }
    }

   
}
