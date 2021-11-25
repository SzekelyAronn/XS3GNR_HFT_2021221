using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Logic;

namespace XS3GNR_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IStudentLogic sl;

        public StatController(IStudentLogic sl)
        {
            this.sl = sl;
        }

    }
}
