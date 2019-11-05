using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rfid.Persistence.Domain.Collections;
using RfidApi.Core.Services;
using Rfid.Persistence.UnitOfWorks;
using MongoDB.Bson;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IUnitOfWork _unitOfWork;

        public LogsController(ILogService logService, IUnitOfWork unitOfWork)
        {
            _logService = logService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<Log> GetLogById(string id)
        {
            return await _logService.GetLogById(id);
        }

        [HttpGet("failed")]
        public Task<IEnumerable<Log>> GetAllFailedLogs()
        {
            return _logService.GetAllFailedLogs();
        }

        [HttpGet]
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

        [HttpGet("latest")]
        public Log GetLatestLog()
        {
            return _logService.GetLatestLog();
        }

        [HttpGet("test")]
        public async Task PostNewLog() 
        {
            await _unitOfWork.Logs.AddAsync(new Log
            {
                Uid = null,
                AttemptType = 0,
                Message = "UNIX TEST"
            }).ConfigureAwait(false);
        }
    }
}
