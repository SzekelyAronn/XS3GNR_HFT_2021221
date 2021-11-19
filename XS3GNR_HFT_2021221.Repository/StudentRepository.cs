using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Data;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Repository
{
    public class StudentRepository : IStudentRepository
    {
        UnistudfacDBContext db;

        public StudentRepository(UnistudfacDBContext db)
        {
            this.db = db;
        }

        public void Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public Student Read(int id)
        {
            return db.Students.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Student> ReadAll()
        {
            return db.Students;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Student student)
        {
            var oldStudent = Read(student.Id);
            oldStudent.FacultyId = student.FacultyId;
            oldStudent.Name = student.Name;
            oldStudent.NeptunId = student.NeptunId;
            db.SaveChanges();
        }
    }
}
