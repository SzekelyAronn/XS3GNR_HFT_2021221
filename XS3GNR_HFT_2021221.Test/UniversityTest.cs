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
    class UniversityTest
    {
        UniversityLogic ul;

        [SetUp]
        public void Init()
        {
            var mockUniRepo = new Mock<IUniRepository>();

            Faculty NIK = new Faculty() { Name = "Neumann János Informatikai Kar", Id = 1 };

            var Universities = new List<University>
            {
                new University
                {
                    Id = 1,
                    Name = "testuni",
                    ShortName = "TT"
                }
            }.AsQueryable();

            mockUniRepo.Setup((t) => t.ReadAll())
                .Returns(Universities);

            ul = new UniversityLogic(mockUniRepo.Object);
        }

        [Test]
        public void ReadAllWorks()
        {
            Assert.That(() => ul.ReadAll(), Is.Not.Empty);
        }

        [Test]
        public void CreateTestWithWrongId()
        {
            University uni = new University() { Id = -30, Name = "testuniversity" };

            Assert.That(() => ul.Create(uni), Throws.Exception);
        }



    }
}
