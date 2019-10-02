using System.Threading.Tasks;
using Unosquare.RaspberryIO.Abstractions;

namespace RfidScanner.Helpers
{
    public static class ControlLed
    {
        public static void BlinkLed(IGpioPin led, int blinkTime = 500, int blinkAmount = 1, int blinkWaitTime = 100)
        {
            led.PinMode = GpioPinDriveMode.Output;
            Task.Run(async () =>
            {
                for (var i = 0; i < blinkAmount; i++)
                {
                    led.Write(GpioPinValue.Low);
                    await Task.Delay(blinkTime).ConfigureAwait(false);
                    led.Write(GpioPinValue.High);
                    if (blinkAmount > 1) await Task.Delay(blinkWaitTime).ConfigureAwait(false);
                }
            });
        }
    }
}
