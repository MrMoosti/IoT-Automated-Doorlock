using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IoT.Program;
using System.Device.Spi;

namespace IoT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RFIDController : ControllerBase
    {

        public RFIDController()
        {
            var connection = new SpiConnectionSettings(0, 0);
            connection.ClockFrequency = 500000;

            var spi = SpiDevice.Create(connection);
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        private static async Task CardRead(Mfrc522Controller mfrc522Controller)
        {
            while (true)
            {
                var (status, _) = mfrc522Controller.Request(RequestMode.RequestIdle);

                if (status != Status.OK)
                    continue;

                var (status2, uid) = mfrc522Controller.AntiCollision();
                Console.WriteLine(string.Join(", ", uid));

                await Task.Delay(500);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
