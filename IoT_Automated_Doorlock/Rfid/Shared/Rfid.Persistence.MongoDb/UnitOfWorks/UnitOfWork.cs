using Rfid.Persistence.Repositories;
using Rfid.Persistence.UnitOfWorks;

namespace Rfid.Persistence.MongoDb.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        /// <inheritdoc/>
        public ILogRepository Logs { get; }

        public UnitOfWork(ILogRepository logRepository)
        {
            Logs = logRepository;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }
    }
}
