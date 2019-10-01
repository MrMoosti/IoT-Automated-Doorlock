using Iot.Units;
using RfidApi.Core.Exceptions;

namespace RfidApi.Core.Services
{

    public interface ICpuTempService
    {

        /// <summary>
        /// Get the CPU temperature.
        /// </summary>
        /// <exception cref="CpuTempNotAvailableException">Throws the <see cref="Temperature"/> error is the cpu temp is not available.</exception>
        /// <returns>
        /// The CPU <see cref="CpuTempNotAvailableException"/>.
        /// </returns>
        Temperature GetCpuTemp();
    }
}