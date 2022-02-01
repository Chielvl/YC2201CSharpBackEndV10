using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        public DatabaseContext dbc;

        public MealController(DatabaseContext dbContext)
        {
            dbc = dbContext;
        }

        // GET api/<MealController>/5
        [HttpGet("GetMeal/")]
        public Meal Get([FromBody]Meal meal)
        {

            return meal;
        }

        // POST api/<MealController>
        [HttpPost]
        public void Post([FromBody] Meal m)
        {
            dbc.Add(m);
            dbc.SaveChanges();
        }

        // PUT api/<MealController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
