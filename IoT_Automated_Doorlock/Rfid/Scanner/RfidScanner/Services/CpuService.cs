using System.Threading.Tasks;
using Rfid.Persistence.Domain.Enums;
using Rfid.Persistence.UnitOfWorks;
using Iot.Device.CpuTemperature;
using System;
using Rfid.Persistence.Domain.Collections;

namespace RfidScanner.Services
{

    public class CpuService
    {

        private readonly IUnitOfWork _unitOfWork;


        public CpuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SaveCpuTemperature()
        {
            var cpu = new CpuTemperature();
            while (true)
            {
                if(cpu.IsAvailable)
                {
                    var cpuString  = $"The CPU temperature in Celsius is {cpu.Temperature.Celsius} C";
                    Console.WriteLine(cpuString);

                    if(cpu.Temperature.Celsius <= 10) 
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.Critical
                        }).ConfigureAwait(false);
                    }
                    else if(cpu.Temperature.Celsius > 10 && cpu.Temperature.Celsius <= 20) 
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.Cold
                        }).ConfigureAwait(false);
                    }
                    else if(cpu.Temperature.Celsius > 20 && cpu.Temperature.Celsius <= 55)
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.Ok
                        }).ConfigureAwait(false);
                    }
                    else if(cpu.Temperature.Celsius > 55 && cpu.Temperature.Celsius >= 65)
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.Hot
                        }).ConfigureAwait(false);
                    }
                    else
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.Critical
                        }).ConfigureAwait(false);
                    }
                    
                }
                await Task.Delay(2000).ConfigureAwait(false);
            }
        }
    }
}