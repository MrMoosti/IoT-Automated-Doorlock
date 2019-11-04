using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
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
            var firstDay = ((DateTimeOffset)startOfTthisMonth).ToUnixTimeSeconds();
            var lastDay = ((DateTimeOffset)startOfTthisMonth.AddMonths(1).AddDays(-1)).ToUnixTimeSeconds();
            return _unitOfWork.Logs.WhereAsync(x => x.UnixTime >= firstDay && x.UnixTime <= lastDay);
        }

        public Task<IEnumerable<Log>> GetAllLogsFromThisWeek()
        {
            DateTime startOfWeek = DateTime.Today;
            int delta = DayOfWeek.Monday - DateTime.Today.DayOfWeek;
            var unixStartOfWeek = ((DateTimeOffset)startOfWeek.AddDays(delta)).ToUnixTimeSeconds();
            var unixEndOfWeek = ((DateTimeOffset)startOfWeek.AddDays(7)).ToUnixTimeSeconds();

            return _unitOfWork.Logs.WhereAsync(x => x.UnixTime > unixStartOfWeek && x.UnixTime < unixEndOfWeek);
        }

        public Task<IEnumerable<Log>> GetAllLogsFromToday()
        {
            var currentDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Now.Day);
            var unixCurrentDay = ((DateTimeOffset)currentDay).ToUnixTimeSeconds();
            var unixTomorrow = ((DateTimeOffset)currentDay.AddDays(1)).ToUnixTimeSeconds();
            return _unitOfWork.Logs.WhereAsync(x => x.UnixTime >= unixCurrentDay && x.UnixTime <= unixTomorrow);
        }

        public Task<IEnumerable<Log>> GetAllSucceededLogs()
        {
            return _unitOfWork.Logs.WhereAsync(x => x.AttemptType == AttemptType.Success);
        }

        public Log GetLatestLog()
        {
            var logs = _unitOfWork.Logs.GetLastDocuments(1);
            return logs[0];
        }

        public Task<Log> GetLogById(string id)
        {
            ObjectId objectId = ObjectId.Parse(id);
            var foundLog = _unitOfWork.Logs.FindAsync(x => x.BsonObjectId == objectId);
            return foundLog;
        }
    }
}