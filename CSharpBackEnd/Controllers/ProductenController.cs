using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductenController : ControllerBase
    {
        DatabaseContext databaseContext;

        public ProductenController(DatabaseContext dbContext)
        {
            databaseContext = dbContext;
        }

        // GET: api/<ProductenController>
        // GET: api/<ProductenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductenController>/5
        [HttpGet("{id}")]
        public Product GetProduct(int productId)
        {
            var product = databaseContext.Find<Product>(productId);

            return product;
        }


        // POST api/<ProductenController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // DELETE api/<ProductenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
