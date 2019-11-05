using Iot.Device.CpuTemperature;
using Iot.Units;
using RfidApi.Core.Exceptions;

namespace RfidApi.Core.Services.Implementations
{
    public class CpuService : ICpuTempService
    {

        public Temperature GetCpuTemp()
        {
            var temperature = new CpuTemperature();
            if (temperature.IsAvailable)
            {
                return temperature.Temperature;
            }
            else
            {
                throw new CpuTempNotAvailableException("Error: CPU Temperature not available!");
            }
        }
    }
}