using System;
using System.Timers;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace RfidApi.Core.Led
{
    public class BlinkLed
    {
        private IGpioPin _ledPin;

        public BlinkLed()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Initialize abstraction implementation.
            Pi.Init<BootstrapWiringPi>();
            _ledPin = Pi.Gpio[BcmPin.Gpio22];
            _ledPin.PinMode = GpioPinDriveMode.Output;
            _ledPin.Write(GpioPinValue.High);

            var isOn = false;
            for (var i = 0; i < 1000; i++)
            {
                isOn = !isOn;
                _ledPin.Write(isOn);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}