using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsDishComponentController : ControllerBase
    {
        DatabaseContext dbc;

        public MealsDishComponentController(DatabaseContext dbContext)
        {
            dbc = dbContext;
        }

        // GET: api/<MealsDishComponentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MealsDishComponentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MealsDishComponentController>
        [HttpPost]
        public void Post([FromBody] MealsDishComponentController mdc)
        {





            dbc.Add(mdc);
            dbc.SaveChanges();
        }

        // PUT api/<MealsDishComponentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealsDishComponentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
