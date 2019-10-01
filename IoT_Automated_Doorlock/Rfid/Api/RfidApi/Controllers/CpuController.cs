using Microsoft.AspNetCore.Mvc;
using RfidApi.Core.Services;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {

        private readonly ICpuTempService _cpuTempService;

        public CpuController(ICpuTempService cpuTempService)
        {
            _cpuTempService = cpuTempService;
        }

        [HttpGet("celsius")]
        public double GetCelsius()
        {
            return _cpuTempService.GetCpuTemp().Celsius;
        }
    }
}
