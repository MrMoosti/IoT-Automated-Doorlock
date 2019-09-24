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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
