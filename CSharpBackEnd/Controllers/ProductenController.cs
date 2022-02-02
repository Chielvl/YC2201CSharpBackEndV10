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

        // GET api/<ProductenController>/5
        [HttpGet("{productId}")]
        public Voedingswaarden GetProduct(int productId)
        {                                                                                    //Check database for product with same id
            var product = dbc.Find<Voedingswaarden>(productId);

            return product;
        }

        [HttpGet("find/{productName}")]
        public Voedingswaarden GetProductByName(string productName) 
        {
            Voedingswaarden product = new Voedingswaarden();
            try
            {                                                                               //Check database for product with same name. Return one entry
                product = dbc.Voedingswaarden.Where(p => p.Name == productName).Single();   //Single() return error if more than one entry is present
            }
            catch (Exception ex)
            {
                                                                                            //Empty catch to return empty Voedingswaarden
            }
           
            return product;
        }
    }
}
