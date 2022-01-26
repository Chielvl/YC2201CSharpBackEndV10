using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        DatabaseContext nieuweBarcode;

        public BarcodeController(DatabaseContext databaseContext)
        {
            nieuweBarcode = databaseContext;
        }

        // GET: api/<BarcodeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Barcode barcode = new Barcode();
            barcode.Gewicht = 25;
            barcode.InputField = "wat tekst";
            nieuweBarcode.Add(barcode);
            nieuweBarcode.SaveChanges();
            return new string[] { "value1", "value2" };
            
        }

        // GET api/<BarcodeController>/5
        [HttpGet("{code}")]
        public string Get(string code)
        {
            var barcodeProduct = nieuweBarcode.Find<Barcode>(code);
            if (barcodeProduct != null)
            {
                return barcodeProduct.InputField;
            }
            return "Onbekend";
        }
            

        // POST api/<BarcodeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BarcodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BarcodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
