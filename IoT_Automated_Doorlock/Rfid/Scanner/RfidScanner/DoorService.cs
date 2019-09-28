using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Domain.Enums;
using Rfid.Persistence.UnitOfWorks;
using RfidScanner.Helper;
using Swan;
using Swan.Logging;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Peripherals;

namespace RfidScanner
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
            var doors = await _unitOfWork.DoorState.GetAllAsync();
            var door = doors[0];
            door.DoorStatus = status;
            await _unitOfWork.DoorState.UpdateValue(x => x.BsonObjectId, door.BsonObjectId, x => x.DoorStatus, door.DoorStatus).ConfigureAwait(false);
        }
    }
}