using Rfid.Persistence.UnitOfWorks;
using RfidScanner.Services;
using System;
using Iot.Device.CpuTemperature;
using System.Threading.Tasks;
using Swan.Logging;

namespace RfidScanner
{

    public class CpuTemp
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CpuService _cpuService;

        public CpuTemp(IUnitOfWork unitOfWork, CpuService cpuService)
        {
            _unitOfWork = unitOfWork;
            _cpuService = cpuService;

        }

        public Task Initialize()
        {
            Console.Clear();
            return Run();
        }

        private async Task Run()
        {
            "Reading CPU Temprature...".Info();
            await _cpuService.SaveCpuTemprature();
        }
    }
}
