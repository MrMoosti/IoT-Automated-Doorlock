using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RfidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RfidController : ControllerBase
    {
        // GET: api/Rfid/all
        [HttpGet("all")]
        public IEnumerable<string> Get()
        {
            return new [] { "value1", "value2" };
        }

        // GET: api/Rfid/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rfid
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rfid/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
