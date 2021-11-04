using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Data;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Repository
{
    class StudentRepository
    {
        UnistudfacDBContext db;

        public StudentRepository(UnistudfacDBContext db)
        {
            this.db = db;
        }

        public void Create(Students student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public Students Read(int id)
        {
            return db.Students.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Students> ReadAll()
        {
            return db.Students;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Students student)
        {
            var oldStudent = Read(student.Id);
            oldStudent.FacultyId = student.FacultyId;
            oldStudent.Name = student.Name;
            oldStudent.NeptunId = student.NeptunId;
            db.SaveChanges();
        }
    }
}
