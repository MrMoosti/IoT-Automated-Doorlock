using Microsoft.AspNetCore.Mvc;
using RfidApi.Core.Services;
using Rfid.Persistence.UnitOfWorks;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rfid.Persistence.Domain.Collections;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoorService _doorService;

        public DoorController(IUnitOfWork unitOfWork, IDoorService doorService)
        {
            _unitOfWork = unitOfWork;
            _doorService = doorService;
        }

        [HttpGet("state")]
        public Task<IEnumerable<Door>> GetCurrentDoorState()
        {
            return _doorService.GetCurrentDoorState();
        }
    }
}
