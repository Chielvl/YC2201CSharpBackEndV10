using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ClassLibrary1;
using CSharpBackEnd.Controllers;
using RestSharp;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpBackEnd
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerechtController : ControllerBase
    {
        int hoeveelheidProducten;

        DatabaseContext dbc;
        ProductenController pc;
        VoedingswaardenController vc;
        Voedingswaarden totalNutrients;

        private Voedingswaarden[] Nutrients;
        private int[] WeightValues;

        public GerechtController(DatabaseContext dbContext)
        {
            dbc = dbContext;
            pc = new ProductenController(dbContext);
            vc = new VoedingswaardenController(dbContext);
        }

        [HttpGet("Test")]
        public string Welcome()
        {
            return "Welcome";
        }

        [HttpPost("MakeDish")]
        public int MakeDish([FromBody] Gerecht g)
        {
            Gerecht gerecht = new Gerecht();
            try
            {                                                                       //check to see if the dish with this name is already present in the database
                gerecht = dbc.Gerecht.Where(p => p.Naam == g.Naam).Single();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                                  
            }
            if (!gerecht.Equals(g))                                                 //check to see if the dish with this name is the same based on productID or ingredients
            {                                                                       //if not, save a new one.
                dbc.Add(g);
                dbc.SaveChanges();
                return g.Id;
            }                                                                       //if so, update the dish

            //update gerecht
            
            return g.Id;
        }

        [HttpPost("Totalen")]
        public int StringToList([FromBody] Gerecht gerecht)                         //receive dish as an object
            {
             ListMaker(gerecht);                                                    //save products and weights in two seperate arrays, for looping purposes
            
            totalNutrients = new Voedingswaarden();

            if(gerecht.Naam != null)
                totalNutrients.Name = gerecht.Naam;                                 //give dish a name

            for (int p = 0; p < Nutrients.Length; p++)
            {
                if (Nutrients[p] == null)
                    continue;                                                      //skip all empty product indexes in array
                            
                Voedingswaarden productVW = Nutrients[p];                          //add all nutrients of the product into the combined nutrient
                totalNutrients.EnergieKcal += productVW.EnergieKcal * WeightValues[p];
                totalNutrients.EnergieKj += (productVW.EnergieKj * WeightValues[p]);
                totalNutrients.Water += (productVW.Water * WeightValues[p]);
                totalNutrients.Eiwit += (productVW.Eiwit * WeightValues[p]);
                totalNutrients.Koolhydraten += (productVW.Koolhydraten * WeightValues[p]);
                totalNutrients.Suikers += (productVW.Suikers * WeightValues[p]);
                totalNutrients.Vet += (productVW.Vet * WeightValues[p]);
                totalNutrients.VerzadigdVet += (productVW.VerzadigdVet * WeightValues[p]);
                totalNutrients.EnkelvoudigVerzadigd += (productVW.EnkelvoudigVerzadigd * WeightValues[p]);
                totalNutrients.MeervoudigVerzadigd += (productVW.MeervoudigVerzadigd * WeightValues[p]);
                totalNutrients.Cholesterol += (productVW.Cholesterol * WeightValues[p]);
                totalNutrients.VoedingsVezels += (productVW.VoedingsVezels * WeightValues[p]);
            }

            vc.Makenutrient(totalNutrients);                                    //save nutrients to database;
            MakeDish(gerecht);                                                  //save dish to database;
            return totalNutrients.Id;                                           //return combined nutrients by id to webapp
        }       

        private void ListMaker(Gerecht g)       
        {
            Nutrients = new Voedingswaarden[]                                   //save products in an array, for looping purposes
            {
                vc.GetNutrients(g.Product1Id),
                vc.GetNutrients(g.Product2Id),
                vc.GetNutrients(g.Product3Id),
                vc.GetNutrients(g.Product4Id),
                vc.GetNutrients(g.Product5Id)
            };
            WeightValues = new int[]                                            //save weights in an array, for looping purposes
            {
                g.Weight1,
                g.Weight2,
                g.Weight3,
                g.Weight4,
                g.Weight5
            };
        }
}
