using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurnedCaloriesController : ControllerBase
    {
        // GET: api/<BurnedCaloriesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BurnedCaloriesController>/5
        [HttpGet("{weight}/{sportTime}/{sport}")]
        public async Task<string> GetAsync(string weight, string sportTime, string sport)
        {
            bool weightBool = double.TryParse(weight, out double weightDouble);
            bool sportTimeBool = double.TryParse(sportTime, out double sportTimeDouble);
            if (weightBool && sportTimeBool)
            {
                //Make the url to call the Python Endpoint
                string webRequest = "https://yc2201pydoc.azurewebsites.net/sportLookup/" + sport;
                //create client to call endpoint and retrieve data
                HttpClient client = new HttpClient();
                var response = client.GetStringAsync(webRequest);
                var calories = await response;

                //calculate the burned calories
                double.TryParse(calories, out double caloriesDouble);
                double burnedCalories = caloriesDouble * weightDouble * sportTimeDouble;
                return burnedCalories.ToString();

                
            }
            else
            {
                return "Invalid attempt: weight and or sportTime could not be parsed.";
            }
            
        }

        // POST api/<BurnedCaloriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BurnedCaloriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BurnedCaloriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
