using Iot.Units;

namespace RfidApi.Core.Services
{

    public interface ICpuTempService
    {
        Temperature GetCpuTemp();
    }
}