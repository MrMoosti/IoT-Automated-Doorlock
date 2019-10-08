using System.Threading.Tasks;
using Rfid.Persistence.Domain.Enums;
using Rfid.Persistence.UnitOfWorks;

namespace RfidScanner.Services
{

    public class DoorService
    {

        private readonly IUnitOfWork _unitOfWork;


        public DoorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateDoorStateAsync(DoorStatus status)
        {
            var doors = await _unitOfWork.Door.GetAllAsync().ConfigureAwait(false);
            var door = doors[0];
            door.DoorStatus = status;
            await _unitOfWork.Door.UpdateValue(x => x.BsonObjectId, door.BsonObjectId, x => x.DoorStatus, door.DoorStatus).ConfigureAwait(false);
        }
    }
}