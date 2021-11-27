using ConsoleTools;
using System;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:29075");

            ConsoleMenu consolemenu = new ConsoleMenu();

            consolemenu.Add("List all Student", () => {
                var res = rest.Get<Student>("/student");
                foreach (var item in res)
                {
                    Console.WriteLine(new
                    {
                        Id = item.Id,
                        Name = item.Name,
                        NeptunId = item.NeptunId,
                        FacultyId = item.FacultyId,
                        BirthDate = item.BirthDate
                    });
                }
                Console.ReadLine();
            });

            consolemenu.Add("List all University", () => {
                var res = rest.Get<University>("/university");
                foreach (var item in res)
                {
                    Console.WriteLine(new
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ShortName = item.ShortName
                    });
                }
                Console.ReadLine();
            });

            consolemenu.Add("List all Faculty", () => {
                var res = rest.Get<Faculty>("/faculty");
                foreach (var item in res)
                {
                    Console.WriteLine(new
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ShortName = item.ShortName,
                        LocationbyDistrict = item.LocationbyDistrict,
                        UniversityId = item.UniversityId
                    });
                }
                Console.ReadLine();
            });

            consolemenu.Add("Read a Student", () => {
               Student result = rest.Get<Student>(1, "/student");
                Console.WriteLine(new
                {
                    Id = result.Id,
                    Name = result.Name,
                    NeptunId= result.NeptunId,
                    BirthDate=result.BirthDate,
                    FacultyId=result.FacultyId
                    
                });
                Console.ReadLine();

            });

            consolemenu.Add("Read a University", () => {
                University result = rest.Get<University>(1, "/university");
                Console.WriteLine(new
                {
                    Id = result.Id,
                    Name = result.Name,
                    Shortname = result.ShortName

                });
                Console.ReadLine();

            });

            consolemenu.Add("Read a Faculty", () => {
                Faculty result = rest.Get<Faculty>(1, "/faculty");
                Console.WriteLine(new
                {
                    Id = result.Id,
                    Name = result.Name,
                    Shortname=result.ShortName,
                    LocationbyDistrict=result.LocationbyDistrict,
                    UniversityId=result.UniversityId

                });
                Console.ReadLine();

            });

            consolemenu.Add("Add new Student", () => {
                rest.Post<Student>(
                    new Student()
                    {
                        Name = "Új hallgató",
                        NeptunId = "ABC123",
                        BirthDate = DateTime.Now,
                        FacultyId = 2

                    },
                    "/student"
                );
            });

            consolemenu.Add("Add new University", () => {
                rest.Post<University>(
                    new University()
                    {
                        Name = "Új Egyetem",
                        ShortName= "ÚE",
                    },
                    "/university"
                );
            });

            consolemenu.Add("Add new Faculty", () => {
                rest.Post<Faculty>(
                    new Faculty()
                    {
                        Name = "Új Kar",
                        ShortName = "ÚK",
                        LocationbyDistrict=5,
                        UniversityId=1,
                    },
                    "/faculty"
                );
            });

            consolemenu.Add("Update Student", () => {
                rest.Put<Student>(
                    new Student()
                    {
                        Id=1,
                        Name="Változtatott tanuló",
                        NeptunId="ABC123",
                        FacultyId=2,
                        BirthDate=new DateTime(2002,02,02)
                    },
                    "/student");
            });

            consolemenu.Add("Update University", () => {
                rest.Put<University>(
                    new University()
                    {
                        Id = 1,
                        Name = "Változtatott Egyetem",
                        ShortName = "VE"

                    },
                    "/university");
            });

            consolemenu.Add("Update Faculty", () => {
                rest.Put<Faculty>(
                    new Faculty()
                    {
                        Id = 1,
                        Name = "Változtatott Kar",
                        ShortName = "VK",
                        LocationbyDistrict = 5,
                        UniversityId=3

                    },
                    "/faculty");
            });

            consolemenu.Add("Delete Student", () => {
                rest.Delete(1, "/student");
            });

            consolemenu.Add("Delete University", () => {
                rest.Delete(5, "/university");
            });

            consolemenu.Add("Delete Faculty", () => {
                rest.Delete(9, "/faculty");
            });

            consolemenu.Add("Students birth before 2000", () => {
                var res = rest.Get<StudentResult>("/stat/GetStudentsFromLastCentury");
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consolemenu.Add("Students with 'X' in their NeptunId", () => {
                var res = rest.Get<StudentResult>("/stat/GetStudentsWithXInNeptun");
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consolemenu.Add("Students Average Age by University", () => {
                var res = rest.Get<StudentsAverage>("/stat/GetAvgAgeByUni");
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consolemenu.Add("Univerities with engineer faculty/faculties", () => {
                var res = rest.Get<EngineerUnis>("/stat/GetEngineerSchools");
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consolemenu.Add("Universities in Budapest 5th district", () => {
                var res = rest.Get<UnisbyDistrict>("/stat/GetUnisInDistrict5");
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consolemenu.Show();
        }
    }
}
