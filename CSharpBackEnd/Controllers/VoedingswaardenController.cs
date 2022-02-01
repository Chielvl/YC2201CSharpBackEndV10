using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoedingswaardenController : ControllerBase
    {
        DatabaseContext dbc;

        public VoedingswaardenController(DatabaseContext dbContext)
        {
            dbc = dbContext;
        }

        [HttpGet("findById/{nutrientsId}")]
        public Voedingswaarden GetNutrients(int nutrientsId)
        {
            Voedingswaarden Nutrients = dbc.Find<Voedingswaarden>(nutrientsId);

            return Nutrients;
        }

        [HttpGet("findByName/{nutrientName}")]
        public Voedingswaarden GetNutrientByName(string nutrientName)
        {
            try
            {
                Voedingswaarden nutrient = dbc.Voedingswaarden.Where<Voedingswaarden>(p => p.Name == nutrientName).FirstOrDefault();
                return nutrient;
            }
            catch (Exception ex)
            {
                return new Voedingswaarden();
            }
        }


        [HttpPost("Makenutrient")]
        public int Makenutrient([FromBody] Voedingswaarden v)
        {
            dbc.Add(v);
            dbc.SaveChanges();
            return v.Id;
        }
    }
}
