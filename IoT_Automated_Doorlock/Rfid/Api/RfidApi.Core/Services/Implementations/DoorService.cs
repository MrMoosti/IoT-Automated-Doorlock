using System.Collections.Generic;
using System.Threading.Tasks;
using Rfid.Persistence.Domain.Collections;

namespace RfidApi.Core.Services.Implementations
{

    public class DoorService : IDoorService
    {
        public Task<IEnumerable<Door>> GetCurrentDoorState()
        {
            throw new System.NotImplementedException();
        }
    }
}