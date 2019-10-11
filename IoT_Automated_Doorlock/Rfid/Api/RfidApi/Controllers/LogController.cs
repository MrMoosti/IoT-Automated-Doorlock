using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rfid.Persistence.Domain.Collections;
using RfidApi.Core.Services;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet("failed")]
        public Task<IEnumerable<Log>> GetAllFailedLogs()
        {
            return _logService.GetAllFailedLogs();
        }

        [HttpGet("all")]
        public Task<IEnumerable<Log>> GetAllLogs()
        {
            return _logService.GetAllLogs();
        }

        [HttpGet("current-month")]
        public Task<IEnumerable<Log>> GetAllLogsFromThisMonth()
        {
            return _logService.GetAllLogsFromThisMonth();
        }

        [HttpGet("current-week")]
        public Task<IEnumerable<Log>> GetAllLogsFromThisWeek()
        {
            return _logService.GetAllLogsFromThisWeek();
        }

        [HttpGet("today")]
        public Task<IEnumerable<Log>> GetAllLogsFromToday()
        {
            return _logService.GetAllLogsFromToday();
        }

        [HttpGet("succeeded")]
        public Task<IEnumerable<Log>> GetAllSucceededLogs()
        {
            return _logService.GetAllSucceededLogs();
        }
    }
}
