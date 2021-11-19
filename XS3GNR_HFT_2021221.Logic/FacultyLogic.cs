using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Models;
using XS3GNR_HFT_2021221.Repository;

namespace XS3GNR_HFT_2021221.Logic
{
    class FacultyLogic
    {
        IFacultyRepository facultyRepo;

        public FacultyLogic(IFacultyRepository facultyRepo)
        {
            this.facultyRepo = facultyRepo;
        }

        public void Create(Faculty faculty)
        {
            facultyRepo.Create(faculty);
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
    }


}

