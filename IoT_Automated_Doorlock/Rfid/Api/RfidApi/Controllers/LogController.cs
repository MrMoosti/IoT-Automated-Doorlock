using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rfid.Persistence.Domain.Collections;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        [HttpGet("failed")]
        public Task<IEnumerable<Log>> GetAllFailedLogs()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("all")]
        public Task<IEnumerable<Log>> GetAllLogs()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("current-month")]
        public Task<IEnumerable<Log>> GetAllLogsFromThisMonth()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("current-week")]
        public Task<IEnumerable<Log>> GetAllLogsFromThisWeek()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("today")]
        public Task<IEnumerable<Log>> GetAllLogsFromToday()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("succeeded")]
        public Task<IEnumerable<Log>> GetAllSucceededLogs()
        {
            throw new System.NotImplementedException();
        }
    }
}
