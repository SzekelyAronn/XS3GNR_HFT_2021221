using System.Linq;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Repository
{
    public interface IFacultyRepository
    {
        void Create(Faculty faculty);
        void Delete(int id);
        Faculty Read(int id);
        IQueryable<Faculty> ReadAll();
        void Update(Faculty faculty);
    }
}