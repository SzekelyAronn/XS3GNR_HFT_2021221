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

            consolemenu.Show();
        }
    }
}
