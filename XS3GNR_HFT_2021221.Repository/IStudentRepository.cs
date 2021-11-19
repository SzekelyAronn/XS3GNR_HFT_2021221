using System.Linq;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Repository
{
    public interface IStudentRepository
    {
        void Create(Student student);
        void Delete(int id);
        Student Read(int id);
        IQueryable<Student> ReadAll();
        void Update(Student student);
    }
}