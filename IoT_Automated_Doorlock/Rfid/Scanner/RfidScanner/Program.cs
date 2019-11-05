using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Swan;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

[assembly: AssemblyInformationalVersion("1.0.*")]
[assembly: AssemblyProduct("Rfid Scanner")]
[assembly: AssemblyTitle("RfidScanner")]
[assembly: AssemblyVersion("1.0.*")]

namespace RfidScanner
{
    internal class Program
    {
        private static async Task Main()
        {
            Unity.RegisterTypes();
            Pi.Init<BootstrapWiringPi>();
            await Unity.Resolve<Scanner>().Initialize().ConfigureAwait(false);
        }
    }
}

