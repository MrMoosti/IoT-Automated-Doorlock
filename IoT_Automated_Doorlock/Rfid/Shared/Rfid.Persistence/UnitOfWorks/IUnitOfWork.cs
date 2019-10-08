using System;
using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Repositories;

namespace Rfid.Persistence.UnitOfWorks
{

    /// <summary>
    /// This UnitOfWork contains all the Repositories used to query the all the tables/collections.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Contains all the queries to the <see cref="Log"/> table/collection.
        /// </summary>
        ILogRepository Logs { get; }
        IDoorRepository Door { get; }
        ICpuRepository CpuTemprature { get; }
    }
}
