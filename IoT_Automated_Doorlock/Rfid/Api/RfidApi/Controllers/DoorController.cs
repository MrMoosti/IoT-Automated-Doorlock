using Microsoft.AspNetCore.Mvc;
using RfidApi.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Domain.Enums;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {

        private readonly IDoorService _doorService;

        public DoorController(IDoorService doorService)
        {
            _doorService = doorService;
        }

        [HttpGet("state")]
        public async Task<DoorStatus> GetCurrentDoorState()
        {
            var door = await _doorService.GetCurrentDoorState().ConfigureAwait(false);
            return door.DoorStatus;
        }
    }
}
