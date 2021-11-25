using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Logic;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {

        IFacultyLogic fl;

        public FacultyController(IFacultyLogic fl)
        {
            this.fl = fl;
        }

        [HttpGet]
        public IEnumerable<Faculty> Get()
        {
            return fl.ReadAll();
        }

        [HttpGet("{id}")]
        public Faculty Get(int id)
        {
            return fl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Faculty value)
        {
            fl.Create(value);
        }

        [HttpPut]
        public void Put(int id, [FromBody] Faculty value)
        {
            fl.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            fl.Delete(id);
        }
    }
}
