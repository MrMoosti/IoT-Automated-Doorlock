using System.Collections.Generic;
using System.Threading.Tasks;
using Rfid.Persistence.Domain.Collections;

namespace RfidApi.Core.Services.Implementations
{

    public class LogService : ILogService
    {
        public Task<IEnumerable<User>> GetAllFailedLogs()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllLogs()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Door>> GetAllLogsFromThisMonth()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Door>> GetAllLogsFromThisWeek()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Door>> GetAllLogsFromToday()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Door>> GetAllSucceededLogs()
        {
            throw new System.NotImplementedException();
        }
    }
}