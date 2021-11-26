using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Models;
using XS3GNR_HFT_2021221.Repository;

namespace XS3GNR_HFT_2021221.Logic
{
    public class FacultyLogic : IFacultyLogic
    {
        IFacultyRepository facultyRepo;

        public FacultyLogic(IFacultyRepository facultyRepo)
        {
            this.facultyRepo = facultyRepo;
        }

        public void Create(Faculty faculty)
        {
            if (faculty.UniversityId < 1)
            {
                throw new ArgumentException("Id cannot be negative");
            }
            else
            {
                facultyRepo.Create(faculty);
            }
            
        }

        public Faculty Read(int id)
        {
            return facultyRepo.Read(id);
        }

        public IQueryable<Faculty> ReadAll()
        {
            return facultyRepo.ReadAll();
        }

        public void Delete(int id)
        {
            facultyRepo.Delete(id);
        }

        public void Update(Faculty faculty)
        {
            facultyRepo.Update(faculty);
        }

        public IEnumerable<EngineerUnis> EngineerSchools()
        {

            var result = from x in facultyRepo.ReadAll()
                         where x.Name.Contains("mérnök")
                         select new EngineerUnis
                         {
                             UniversityName = x.University.Name,
                             FacultyShortName = x.ShortName,
                             FacultyName = x.Name
                         };

            return result.ToArray();

        }

        public IEnumerable<UnisbyDistrict> UniversitiesInDistrict5()
        {
            var result = from x in facultyRepo.ReadAll()
                         where x.LocationbyDistrict == 5
                         select new UnisbyDistrict
                         {
                             UniversityName = x.University.Name,
                             FacultyName = x.Name,
                             LocationbyDistrict = x.LocationbyDistrict
                         };

            return result.ToArray();
        }






    }


}

