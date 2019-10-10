using System.Collections.Generic;
using System.Threading.Tasks;
using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Domain.Enums;

namespace RfidApi.Core.Services
{

    public interface IDoorService
    {
        Task<Door> GetCurrentDoorState();

    }
}