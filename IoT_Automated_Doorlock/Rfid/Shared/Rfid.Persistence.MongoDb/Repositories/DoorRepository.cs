using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Repositories;

namespace Rfid.Persistence.MongoDb.Repositories
{
    public class DoorRepository : Repository<Door>, IDoorRepository
    {

        public DoorRepository(MongoContext context) : base(context, nameof(Door) + "s")
        {
            
        }

    }
}