using System.Threading.Tasks;
using Rfid.Persistence.Domain.Enums;
using Rfid.Persistence.UnitOfWorks;
using Iot.Device.CpuTemperature;
using System;
using System.Threading;
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

        public async Task SaveCpuTemprature()
        {
            CpuTemperature cpu = new CpuTemperature();
            while (true)
            {
                if(cpu.IsAvailable)
                {
                    string cpu_string  = $"The CPU temperature in Celsius is {cpu.Temperature.Celsius} C";
                    Console.WriteLine(cpu_string);

                    if(cpu.Temperature.Celsius <= 10) 
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.CRITICAL
                        }).ConfigureAwait(false);
                    }
                    else if(cpu.Temperature.Celsius > 10 && cpu.Temperature.Celsius <= 20) 
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.COLD
                        }).ConfigureAwait(false);
                    }
                    else if(cpu.Temperature.Celsius > 20 && cpu.Temperature.Celsius <= 55)
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.OK
                        }).ConfigureAwait(false);
                    }
                    else if(cpu.Temperature.Celsius > 55 && cpu.Temperature.Celsius >= 65)
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.HOT
                        }).ConfigureAwait(false);
                    }
                    else
                    {
                        await _unitOfWork.CpuTemprature.AddAsync(new Cpu
                        {
                            Temprature = cpu.Temperature.Celsius,
                            State = CpuState.CRITICAL
                        }).ConfigureAwait(false);
                    }
                    
                }
                Thread.Sleep(2000);
            }
        }
    }
}