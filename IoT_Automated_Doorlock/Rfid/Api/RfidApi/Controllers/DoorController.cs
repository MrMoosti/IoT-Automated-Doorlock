using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        /// <summary>
        /// Get the cpu temperature in celsius.
        /// </summary>
        /// <example>
        /// GET: api/CpuTemp/celsius
        /// </example>
        /// <returns>
        /// The CPU temp in celsius.
        /// </returns>
        [HttpGet("celsius")]
        public double GetCelsius()
        {
            return _cpuTempService.GetCpuTemp().Celsius;
        }


        /// <summary>
        /// Get the cpu temperature in fahrenheit.
        /// </summary>
        /// <example>
        /// GET: api/CpuTemp/fahrenheit
        /// </example>
        /// <returns>
        /// The CPU temp in fahrenheit.
        /// </returns>
        [HttpGet("fahrenheit")]
        public double GetFahrenheit()
        {
            return _cpuTempService.GetCpuTemp().Fahrenheit;
        }


        /// <summary>
        /// Get the cpu temperature in Kelvin.
        /// </summary>
        /// <example>
        /// GET: api/CpuTemp/Kelvin
        /// </example>
        /// <returns>
        /// The CPU temp in Kelvin.
        /// </returns>
        [HttpGet("kelvin")]
        public double GetKelvin()
        {
            return _cpuTempService.GetCpuTemp().Kelvin;
        }

    }
}
