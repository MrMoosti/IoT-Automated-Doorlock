using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rfid.Persistence.Domain.Enums;
using RfidApi.Core.Services;

namespace RfidApi.Controllers;

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