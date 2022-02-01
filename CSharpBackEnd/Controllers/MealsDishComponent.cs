using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsDishComponent : ControllerBase
    {
        DatabaseContext dbc;

        public MealsDishComponent(DatabaseContext dbContext)
        {
            dbc = dbContext;
        }

        // GET: api/<MealsDishComponent>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MealsDishComponent>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MealsDishComponent>
        [HttpPost]
        public void Post([FromBody] MealsDishComponent mdc)
        {





            dbc.Add(mdc);
            dbc.SaveChanges();
        }

        // PUT api/<MealsDishComponent>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealsDishComponent>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
