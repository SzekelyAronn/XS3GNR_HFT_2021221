using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Logic;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        StudentLogic sl;

        public StudentController(StudentLogic sl)
        {
            this.sl = sl;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return sl.ReadAll();
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return sl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Student value)
        {
            sl.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Student value)
        {
            sl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.Delete(id);
        }
    }
}
