using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Repositories;

namespace Rfid.Persistence.MongoDb.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {

        public LogRepository(MongoContext context) : base(context, nameof(Log) + "s")
        {

        }
    }
}
