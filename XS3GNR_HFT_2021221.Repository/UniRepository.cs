using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Data;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Repository
{
    public class UniRepository : IUniRepository
    {
        UnistudfacDBContext db;

        public UniRepository(UnistudfacDBContext db)
        {
            this.db = db;
        }

        public void Create(University university)
        {
            db.Universities.Add(university);
            db.SaveChanges();
        }

        public University Read(int id)
        {
            return db.Universities.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<University> ReadAll()
        {
            return db.Universities;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(University university)
        {
            var oldUni = Read(university.Id);
            oldUni.Faculties = university.Faculties;
            oldUni.Name = university.Name;
            oldUni.ShortName = university.ShortName;
            db.SaveChanges();
        }
    }
}
