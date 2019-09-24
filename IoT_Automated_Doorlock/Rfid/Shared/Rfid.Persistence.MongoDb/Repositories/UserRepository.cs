using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Repositories;

namespace Rfid.Persistence.MongoDb.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MongoContext context) : base(context, nameof(User) + "s")
        {

        }
    }
}