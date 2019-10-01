using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Repositories;

namespace Rfid.Persistence.MongoDb.Repositories
{
    public class CpuRepository : Repository<Cpu>, ICpuRepository
    {

        public CpuRepository(MongoContext context) : base(context, nameof(Cpu) + "Logs")
        {
            
        }

    }
}
