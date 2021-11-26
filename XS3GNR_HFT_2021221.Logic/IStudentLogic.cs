using System.Collections.Generic;
using System.Linq;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Logic
{
    public interface IStudentLogic
    {
        void Create(Student student);
        void Delete(int id);
        Student Read(int id);
        IQueryable<Student> ReadAll();
        IEnumerable<StudentResult> StudentsFromLastCentury();
        IEnumerable<StudentResult> Studentswith_X_inNeptunId();
        IEnumerable<StudentsAverage> AverageStudentAgeByUni();
        void Update(Student student);
    }
}