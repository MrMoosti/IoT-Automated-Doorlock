using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Domain.Enums;
using Rfid.Persistence.UnitOfWorks;

namespace RfidApi.Core.Services.Implementations
{

    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Log>> GetAllFailedLogs()
        {
            return _unitOfWork.Logs.WhereAsync(x => x.AttemptType != AttemptType.Success);
        }

        public async Task<IEnumerable<Log>> GetAllLogs()
        {
            return await _unitOfWork.Logs.GetAllAsync().ConfigureAwait(false);
        }

        public Task<IEnumerable<Log>> GetAllLogsFromThisMonth()
        {
            var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);       
            var firstDay = startOfTthisMonth.AddMonths(-1);
            var lastDay = startOfTthisMonth.AddDays(-1);
            return _unitOfWork.Logs.WhereAsync(x => x.AddedAtUtc >= firstDay && x.AddedAtUtc <= lastDay);
        }

        public Task<IEnumerable<Log>> GetAllLogsFromThisWeek()
        {
            DateTime startOfWeek = DateTime.Today;
            int delta = DayOfWeek.Monday - startOfWeek.DayOfWeek;
            startOfWeek = startOfWeek.AddDays(delta);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            return _unitOfWork.Logs.WhereAsync(x => x.AddedAtUtc > startOfWeek && x.AddedAtUtc < endOfWeek);
        }

        public Task<IEnumerable<Log>> GetAllLogsFromToday()
        {
            var currentDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Now.Day);
            var tomorrow = currentDay.AddDays(1);
            return _unitOfWork.Logs.WhereAsync(x => x.AddedAtUtc >= currentDay && x.AddedAtUtc <= tomorrow);
        }

        public Task<IEnumerable<Log>> GetAllSucceededLogs()
        {
            return _unitOfWork.Logs.WhereAsync(x => x.AttemptType == AttemptType.Success);
        }
    }
}