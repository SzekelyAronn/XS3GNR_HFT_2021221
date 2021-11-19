using System.Linq;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Repository
{
    public interface IUniRepository
    {
        void Create(University university);
        void Delete(int id);
        University Read(int id);
        IQueryable<University> ReadAll();
        void Update(University university);
    }
}