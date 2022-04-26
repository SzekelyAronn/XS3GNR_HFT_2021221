using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Endpoint.Services;
using XS3GNR_HFT_2021221.Logic;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        IStudentLogic sl;
        IHubContext<SignalRHub> hub;

        public StudentController(IStudentLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("StudentCreated", value);
        }

        [HttpPut]
        public void Put(int id, [FromBody] Student value)
        {
            sl.Update(value);
            this.hub.Clients.All.SendAsync("StudentUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var studentdelete = sl.Read(id);
            sl.Delete(id);
            this.hub.Clients.All.SendAsync("StudentDeleted", studentdelete);
        }
    }
}
