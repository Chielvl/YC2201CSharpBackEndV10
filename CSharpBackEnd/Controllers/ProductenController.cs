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
        DatabaseContext dbc;

        public ProductenController(DatabaseContext dbContext)
        {
            dbc = dbContext;
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
        public Voedingswaarden GetProduct(int productId)
        {
            var product = dbc.Find<Voedingswaarden>(productId);

            return product;
        }

        [HttpGet("find/{productName}")]
        public Voedingswaarden GetProductByName(string productName) 
        {
            Voedingswaarden product = new Voedingswaarden();
            try
            {
                product = dbc.Producten.Where(p => p.Name == productName).Single();
            }
            catch (Exception ex)
            {

            }
           
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
