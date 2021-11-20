using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Models;
using XS3GNR_HFT_2021221.Repository;

namespace XS3GNR_HFT_2021221.Logic
{
    public class StudentLogic : IStudentLogic
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

        public IEnumerable<StudentResult> StudentsFromLastCentury()
        {

            var result = from x in studentRepo.ReadAll()
                         where (x.BirthDate.CompareTo(new DateTime(2000, 01, 01)) < 0)
                         select new StudentResult
                         {
                             StudentName = x.Name,
                             StudentNeptunId = x.NeptunId,
                             StudentsUni = x.Faculty.University.Name,
                             StudentFaculty = x.Faculty.Name
                         };

            return result.ToArray();
        }


        public IEnumerable<StudentResult> Studentswith_X_inNeptunId()
        {

            var result = from x in studentRepo.ReadAll()
                         where (x.NeptunId.Contains("X"))
                         select new StudentResult
                         {
                             StudentName = x.Name,
                             StudentNeptunId = x.NeptunId,
                             StudentsUni = x.Faculty.University.Name,
                             StudentFaculty = x.Faculty.Name
                         };

            return result.ToArray();
        }


    }
}
