using System.Threading.Tasks;
using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.UnitOfWorks;

namespace RfidApi.Core.Services.Implementations
{

    public class DoorService : IDoorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Door> GetCurrentDoorState()
        {
            return await _unitOfWork.Door.FindAsync(x => true).ConfigureAwait(false);
        }
    }
}