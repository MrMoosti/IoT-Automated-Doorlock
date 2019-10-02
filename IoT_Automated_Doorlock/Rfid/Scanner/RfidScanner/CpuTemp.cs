using RfidScanner.Services;
using System;
using System.Threading.Tasks;
using Swan.Logging;

namespace RfidScanner
{

    public class CpuTemp
    {
        private readonly CpuService _cpuService;

        public CpuTemp(CpuService cpuService)
        {
            _cpuService = cpuService;

        }

        public Task Initialize()
        {
            Console.Clear();
            return Run();
        }

        private Task Run()
        {
            "Reading CPU Temprature...".Info();
            return _cpuService.SaveCpuTemperature();
        }
    }
}
