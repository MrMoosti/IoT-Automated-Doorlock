using Rfid.Persistence.Repositories;
using Rfid.Persistence.UnitOfWorks;

namespace Rfid.Persistence.MongoDb.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ILogRepository logRepository, IDoorRepository doorRepository, ICpuRepository cpuRepository)
    {
        Logs = logRepository;
        Door = doorRepository;
        CpuTemprature = cpuRepository;
    }

    /// <inheritdoc />
    public ILogRepository Logs { get; }

    public IDoorRepository Door { get; }

    public ICpuRepository CpuTemprature { get; }

    /// <inheritdoc />
    public void Dispose()
    {
    }
}