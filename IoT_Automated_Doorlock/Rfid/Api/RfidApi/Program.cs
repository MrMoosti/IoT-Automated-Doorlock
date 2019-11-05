using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

[assembly: AssemblyInformationalVersion("1.0.*")]
[assembly: AssemblyProduct("Rfid Api")]
[assembly: AssemblyTitle("RfidApi")]
[assembly: AssemblyVersion("1.0.*")]

namespace RfidApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var firstUpInterface = NetworkInterface.GetAllNetworkInterfaces()
                                                   .FirstOrDefault(c => c.NetworkInterfaceType != NetworkInterfaceType.Loopback && c.OperationalStatus == OperationalStatus.Up);
            if (firstUpInterface == null) throw new Exception("Unable to find Ipv4 address!");
            var ipv4 = firstUpInterface.GetIPProperties().UnicastAddresses
                                       .Where(c => c.Address.AddressFamily == AddressFamily.InterNetwork)
                                       .Select(c => c.Address)
                                       .FirstOrDefault()
                                       ?.ToString();

            Console.WriteLine($"Build: {Assembly.GetExecutingAssembly()}, Ip={ipv4}, ProcessId={Process.GetCurrentProcess().Id}");
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls($"https://{ipv4}:5001")
                .UseStartup<Startup>();
        }
    }
}
