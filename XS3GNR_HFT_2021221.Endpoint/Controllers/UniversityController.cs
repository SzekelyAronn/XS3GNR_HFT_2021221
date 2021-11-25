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
    public class UniversityController : ControllerBase
    {

        IUniversityLogic ul;

        public UniversityController(IUniversityLogic ul)
        {
            this.ul = ul;
        }

        [HttpGet]
        public IEnumerable<University> Get()
        {
            return ul.ReadAll();
        }

        [HttpGet("{id}")]
        public University Get(int id)
        {
            return ul.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] University value)
        {
            ul.Create(value);
        }

        [HttpPut]
        public void Put(int id, [FromBody] University value)
        {
            ul.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ul.Delete(id);
        }
    }
}
