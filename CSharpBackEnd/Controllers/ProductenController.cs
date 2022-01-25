using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [HttpGet("{productId}")]
        public Product GetProduct(int productId)
        {
            var product = databaseContext.Find<Product>(productId);

            return product;
        }

        [HttpGet("find/{productNaam}")]
        public Product GetProductByName(string productNaam)
        {
            var product = databaseContext.producten.Where(p => p.Naam == productNaam).Single();
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

        private bool CompareNames(string name1, string name2)
        {
            int missedChars = 0;

            for(int i =0 ; i<name1.Length; i++)
            {
                if(name1[i] != name2[i])
                    missedChars++;
            }

            if(missedChars <= 2)
            
                return true;
            
            return false;
        }
    }
}
