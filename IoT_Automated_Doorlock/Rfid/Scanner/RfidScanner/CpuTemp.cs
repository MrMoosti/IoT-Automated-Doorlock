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
            // Dit is een service van voor de cpu.
            // Deze service haald de temperatuur op van de cpu.
            // Hiermee kan je daarna al de temperaturen uit lezen.
            // De methode SaveCpuTemprature is helaas wel gevaarlijk om aan te roepen omdat het een While(true) gebruikt waarom weet ik niet want,
            // ik had hem ook een tip gegeven om een timer voor dit te gebruiken.
            // De save is ook niet zo mooi omdat hij veel code telkens opnieuw schrijft.
            // Tip: ff bigbrainen m8.
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
