using System.Collections.Generic;
using System.Linq;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Logic
{
    interface IFacultyLogic
    {
        void Create(Faculty faculty);
        void Delete(int id);
        IEnumerable<EngineerUnis> EngineerSchools();
        Faculty Read(int id);
        IQueryable<Faculty> ReadAll();
        IEnumerable<StudentsAverage> StudentAverageNameLength();
        IEnumerable<UnisbyDistrict> UniversitiesInDistrict5();
        void Update(Faculty faculty);
    }
}