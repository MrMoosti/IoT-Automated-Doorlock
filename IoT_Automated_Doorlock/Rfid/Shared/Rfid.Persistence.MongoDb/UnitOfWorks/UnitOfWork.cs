using Rfid.Persistence.Repositories;
using Rfid.Persistence.UnitOfWorks;

namespace Rfid.Persistence.MongoDb.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        /// <inheritdoc/>
        public ILogRepository Logs { get; }
        public IDoorRepository DoorState { get; }

        public ICpuRepository CpuTemprature { get; }

        public UnitOfWork(ILogRepository logRepository, IDoorRepository doorRepository, ICpuRepository cpuRepository)
        {
            Logs = logRepository;
            DoorState = doorRepository;
            CpuTemprature = cpuRepository;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }
    }
}
