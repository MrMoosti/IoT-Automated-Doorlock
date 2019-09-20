using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IoT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RFIDController : ControllerBase
    {
        [HttpPost("check")]
        public async Task<ActionResult<byte[]>> Check([FromBody]byte[] uid)
        {
            string s_uid = string.Join(", ", uid);

            return Ok(s_uid);
        }
    }
}
