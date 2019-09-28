using Rfid.Persistence.Repositories;
using Rfid.Persistence.UnitOfWorks;

namespace Rfid.Persistence.MongoDb.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        /// <inheritdoc/>
        public ILogRepository Logs { get; }
        public IDoorRepository DoorState { get; }

        public UnitOfWork(ILogRepository logRepository, IDoorRepository doorRepository)
        {
            Logs = logRepository;
            DoorState = doorRepository;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }
    }
}
