using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Logic;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IStudentLogic sl;

        IFacultyLogic fl;

        public StatController(IStudentLogic sl, IFacultyLogic fl)
        {
            this.sl = sl;
            this.fl = fl;
        }


        [HttpGet]
        public IEnumerable<StudentsAverage> GetAvgAgeByUni()
        {
            return sl.AverageStudentAgeByUni();
        }

        [HttpGet]
        public IEnumerable<StudentResult> GetStudentsFromLastCentury()
        {
            return sl.StudentsFromLastCentury();
        }

        [HttpGet]
        public IEnumerable<StudentResult> GetStudentsWithXInNeptun()
        {
            return sl.Studentswith_X_inNeptunId();
        }

        [HttpGet]
        public IEnumerable<EngineerUnis> GetEngineerSchools()
        {
            return fl.EngineerSchools();
        }

        [HttpGet]
        public IEnumerable<UnisbyDistrict> GetUnisInDistrict5()
        {
            return fl.UniversitiesInDistrict5();
        }

    }
}
