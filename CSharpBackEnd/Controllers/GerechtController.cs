    using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerechtController : ControllerBase
    {
        // GET: api/<GerechtController>
        [HttpGet]
        public IEnumerable<string> Get() 
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GerechtController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GerechtController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GerechtController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GerechtController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
