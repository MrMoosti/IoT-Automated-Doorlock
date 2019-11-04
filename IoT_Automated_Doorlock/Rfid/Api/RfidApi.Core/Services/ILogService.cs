using System.Collections.Generic;
using System.Threading.Tasks;
using Rfid.Persistence.Domain.Collections;

namespace RfidApi.Core.Services
{
    public interface ILogService
    {
        Task<IEnumerable<Log>> GetAllLogs();

        Task<IEnumerable<Log>> GetAllFailedLogs();

        Task<IEnumerable<Log>> GetAllSucceededLogs();

        Task<IEnumerable<Log>> GetAllLogsFromThisMonth();

        Task<IEnumerable<Log>> GetAllLogsFromThisWeek();

        Task<IEnumerable<Log>> GetAllLogsFromToday();

        Log GetLatestLog();

        Task<Log> GetLogById(string id);
    }
}
