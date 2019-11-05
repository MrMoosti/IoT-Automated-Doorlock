using Microsoft.AspNetCore.Mvc;
using RfidApi.Core.Led;

namespace RfidApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LedController : ControllerBase
    {
        private readonly BlinkLed _blinkLed;

        public LedController(BlinkLed blinkLed)
        {
            _blinkLed = blinkLed;
        }

        [HttpPost("toggle")]
        public void Post()
        {
            _blinkLed.Initialize();
        }
    }
}