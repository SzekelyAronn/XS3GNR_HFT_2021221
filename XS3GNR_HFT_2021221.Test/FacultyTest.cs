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
    class FacultyTest
    {
        FacultyLogic fl;

        [SetUp]
        public void Init()
        {
            var mockfacultRepo = new Mock<IFacultyRepository>();

            University OE = new University() { Id = 1, Name = "Óbudai Egyetem", ShortName = "OE" };
            University BME = new University() { Id = 2, Name = "Budapesti Műszaki és Gazdaságtudományi Egyetem", ShortName = "BME" };
            University BGE = new University() { Id = 3, Name = "Budapesti Gazdasági Egyetem", ShortName = "BGE" };

            Student stud1 = new Student() { Id = 1, Name = "Fehér Dominik", NeptunId = "GV2OA1", BirthDate = new DateTime(2002, 01, 02) };
            Student stud2 = new Student() { Id = 2, Name = "Papp Attila", NeptunId = "H116BR",  BirthDate = new DateTime(1999, 03, 16) };
            Student stud3 = new Student() { Id = 3, Name = "Mészáros Fanni", NeptunId = "K7KJMR",  BirthDate = new DateTime(1999, 08, 13) };

            var faculties = new List<Faculty>
            {
                new Faculty()
                {
                    Id = 1,
                    ShortName = "NIK",
                    Name = "Neumann János Informatikai Kar",
                    UniId = OE.Id,
                    University = OE,
                    LocationbyDistrict = 3
                },
                new Faculty()
                {
                    Id = 2,
                    ShortName = "KJK",
                    Name = "Közlekedésmérnöki és Járműmérnöki Kar",
                    UniId = BME.Id,
                    University = BME,
                    LocationbyDistrict = 11
                },
                new Faculty()
                {
                    Id = 3,
                    ShortName = "KVIK",
                    Name = "Kereskedelmi, Vendéglátóipari és Idegenforgalmi Kar",
                    UniId = BGE.Id,
                    University = BGE,
                    LocationbyDistrict = 5
                }

            }.AsQueryable();

            mockfacultRepo.Setup((t) => t.ReadAll())
                .Returns(faculties);

            fl = new FacultyLogic(mockfacultRepo.Object);
        }

        [Test]
        public void CreateWithWrongId()
        {
            Faculty faculty = new Faculty() { Id = -250, Name = "testfaculty"};

            Assert.That(() => fl.Create(faculty), Throws.Exception);
        }


        [Test]
        public void EngineerTest()
        {
            var result = fl.EngineerSchools();

            var expected = new List<EngineerUnis>()
            {
                new EngineerUnis
                {
                    FacultyName="Közlekedésmérnöki és Járműmérnöki Kar",
                    FacultyShortName="KJK",
                    UniversityName="Budapesti Műszaki és Gazdaságtudományi Egyetem"
                }
            };

            Assert.That(result, Is.EqualTo(result));
        }

        [Test]
        public void LocationTest()
        {
            var result = fl.UniversitiesInDistrict5();

            var expected = new List<UnisbyDistrict>()
            {
                new UnisbyDistrict
                {
                    FacultyName = "Kereskedelmi, Vendéglátóipari és Idegenforgalmi Kar",
                    UniversityName = "Budapesti Gazdasági Egyetem",
                    LocationbyDistrict = 5
                }
            };

            Assert.That(expected,(Is.EqualTo(result)));
        }
    }
}
