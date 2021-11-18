using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Data;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Repository
{
    public class FacultyRepository
    {
        UnistudfacDBContext db;

        public FacultyRepository(UnistudfacDBContext db)
        {
            this.db = db;
        }

        public void Create(Faculty faculty)
        {
            db.Faculties.Add(faculty);
            db.SaveChanges();
        }

        public Faculty Read(int id)
        {
            return db.Faculties.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Faculty> ReadAll()
        {
            return db.Faculties;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Faculty faculty)
        {
            var oldFaculty = Read(faculty.Id);
            oldFaculty.Name = faculty.Name;
            oldFaculty.ShortName = faculty.ShortName;
            oldFaculty.Students = faculty.Students;
            oldFaculty.UniId = faculty.UniId;
            db.SaveChanges();
        }
    }
}
