using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Models;
using XS3GNR_HFT_2021221.Repository;

namespace XS3GNR_HFT_2021221.Logic
{
    class StudentLogic
    {
        IStudentRepository studentRepo;

        public StudentLogic(IStudentRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public void Create(Student student)
        {
            studentRepo.Create(student);
        }

        public Student Read(int id)
        {
            return studentRepo.Read(id);
        }

        public IQueryable<Student> ReadAll()
        {
            return studentRepo.ReadAll();
        }

        public void Delete(int id)
        {
            studentRepo.Delete(id);
        }

        public void Update(Student student)
        {
            studentRepo.Update(student);
        }


    }
}
