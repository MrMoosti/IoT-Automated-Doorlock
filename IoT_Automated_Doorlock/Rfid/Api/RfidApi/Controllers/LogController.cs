using Microsoft.AspNetCore.Mvc;
using RfidApi.Core.Services;
using Rfid.Persistence.UnitOfWorks;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rfid.Persistence.Domain.Collections;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService _logService;

        public LogController(IUnitOfWork unitOfWork, ILogService logService)
        {
            _unitOfWork = unitOfWork;
            _logService = logService;
        }

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
