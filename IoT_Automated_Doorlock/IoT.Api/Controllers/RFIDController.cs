using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoT.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RFIDController : ControllerBase
    {

        public DataContext _context { get; set; }

        public RFIDController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("test")]
        public async Task<ActionResult<byte[]>> Check([FromBody]byte[] uid)
        {
            string s_uid = string.Join(", ", uid);

            var log = new Log{
                UID = s_uid,
                Success = true,
                datetime = DateTime.Now
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();

            return Ok(s_uid);
        }
    }
}
