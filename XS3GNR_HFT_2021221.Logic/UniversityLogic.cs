using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Models;
using XS3GNR_HFT_2021221.Repository;

namespace XS3GNR_HFT_2021221.Logic
{
    public class UniversityLogic : IUniversityLogic
    {
        IUniRepository uniRepo;

        public UniversityLogic(IUniRepository uniRepo)
        {
            this.uniRepo = uniRepo;
        }

        public void Create(University university)
        {
            if (university.Id < 0)
            {
                throw new ArgumentException("Id cannot be negative");
            }
            uniRepo.Create(university);
        }

        public University Read(int id)
        {
            return uniRepo.Read(id);
        }

        public IQueryable<University> ReadAll()
        {
            return uniRepo.ReadAll();
        }

        public void Delete(int id)
        {
            uniRepo.Delete(id);
        }

        public void Update(University university)
        {
            uniRepo.Update(university);
        }
    }
}
