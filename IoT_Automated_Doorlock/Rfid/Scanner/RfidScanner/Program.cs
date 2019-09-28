using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Swan;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;
using Rfid.Persistence.MongoDb;

[assembly: AssemblyInformationalVersion("1.0.*")]
[assembly: AssemblyProduct("Rfid Scanner")]
[assembly: AssemblyTitle("RfidScanner")]
[assembly: AssemblyVersion("1.0.*")]

namespace RfidScanner
{
    internal class Program
    {
        private static readonly Dictionary<ConsoleKey, string> StartOptions = new Dictionary<ConsoleKey, string>
                                                                             {
                                                                                 { ConsoleKey.M, "RFID Menu" },
                                                                                 { ConsoleKey.R, "Program" }
                                                                             };


        private static async Task Main()
        {
            Unity.RegisterTypes();
            Pi.Init<BootstrapWiringPi>();
            var exit = false;

            do
            {
                Console.Clear();
                var mainOption = Terminal.ReadPrompt("Start menu", StartOptions, "Esc to exit this menu");

                switch (mainOption.Key)
                {
                    case ConsoleKey.M:
                        Unity.Resolve<RfidMenu>().Show();
                        break;
                    case ConsoleKey.R:
                        await Unity.Resolve<Scanner>().Initialize().ConfigureAwait(false);
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }
    }
}

