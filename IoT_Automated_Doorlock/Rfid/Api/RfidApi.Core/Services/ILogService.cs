using System.Collections.Generic;
using System.Threading.Tasks;
using Rfid.Persistence.Domain.Collections;

namespace RfidApi.Core.Services
{
    public interface ILogService
    {
        Task<IEnumerable<User>> GetAllLogs();

        Task<IEnumerable<User>> GetAllFailedLogs();

        Task<IEnumerable<Door>> GetAllSucceededLogs();

        Task<IEnumerable<Door>> GetAllLogsFromThisMonth();

        Task<IEnumerable<Door>> GetAllLogsFromThisWeek();

        Task<IEnumerable<Door>> GetAllLogsFromToday();
    }
}
