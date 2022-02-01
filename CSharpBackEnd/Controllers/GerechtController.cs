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
            Gerecht gerecht = dbc.Gerecht.Where(p => p.Naam == g.Naam).Single();
            if (!gerecht.Equals(g))
            {
                dbc.Add(g);
                dbc.SaveChanges();
                return g.Id;
            }

            //update gerecht
            
            return g.Id;
        }

        [HttpGet("FindById/{dishId}")]                                                                    //checked dish op Id;
        public string Getdish(int dishId)
        {
            string msg = "";
            var dish = dbc.Find<Gerecht>(dishId);
            if (dish != null)
            {
                string Product1 = pc.GetProduct(dish.Product1Id).Name;
                msg += Product1;
                string Product2 = pc.GetProduct(dish.Product2Id).Name;
                msg += Product2;
                hoeveelheidProducten = 2;
                if (dish.Weight3 != 0)
                {
                    hoeveelheidProducten = 3;
                    string Product3 = pc.GetProduct(dish.Product3Id).Name;
                    msg += Product3;
                    if (dish.Weight4 != 0)
                    {
                        hoeveelheidProducten = 4;
                        string Product4 = pc.GetProduct(dish.Product4Id).Name;
                        msg += Product4;
                        if (dish.Weight5 != 0)
                        {
                            hoeveelheidProducten = 5;
                            string Product5 = pc.GetProduct(dish.Product5Id).Name;
                            msg += Product5;
                        }
                    }
                }
                return msg;
            }
            return "Onbekend";
        }

        [HttpGet("Producten/{dishId}")]
        public string ProductenLijst(int dishId)                                 //verzameld Producten en zet ze in een lijst. Returned een Nutrients van het totale dish;
        {
            Getdish(dishId);
            var dish = dbc.Find<Gerecht>(dishId);
            Nutrients = new Voedingswaarden[hoeveelheidProducten];
            WeightValues = new int[hoeveelheidProducten];
            Nutrients[0] = pc.GetProduct(dish.Product1Id);
            WeightValues[0] = dish.Weight1;
            Nutrients[1] = pc.GetProduct(dish.Product2Id);
            WeightValues[1] = dish.Weight2;
            if (dish.Weight3 != 0)
            {
                Nutrients[2] = pc.GetProduct(dish.Product3Id);
                WeightValues[2] = dish.Weight3;
                if (dish.Weight4 != 0)
                {
                    Nutrients[3] = pc.GetProduct(dish.Product4Id);
                    WeightValues[3] = dish.Weight4;
                    if (dish.Weight5 != 0)
                    {
                        Nutrients[4] = pc.GetProduct(dish.Product5Id);
                        WeightValues[4] = dish.Weight5;
                    }

                }
            }
            return "hoi";
            //  return NutrientsTotaalMethod(new PassedObject(Producten, WeightWaarden));
        }

        [HttpPost("Totalen")]
        public int StringToList([FromBody] Gerecht gerecht)
            {
             ListMaker(gerecht);
            
            totalNutrients = new Voedingswaarden();

            if(gerecht.Naam != null)
                totalNutrients.Name = gerecht.Naam;

            for (int p = 0; p < Nutrients.Length; p++)
            {
                if (Nutrients[p] == null)
                    continue;

                Voedingswaarden productVW = Nutrients[p];
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

            vc.Makenutrient(totalNutrients);
            MakeDish(gerecht);
            return totalNutrients.Id;
        }

        private void ListMaker(Gerecht g)
        {
            Nutrients = new Voedingswaarden[] {
                vc.GetNutrients(g.Product1Id),
                vc.GetNutrients(g.Product2Id),
                vc.GetNutrients(g.Product3Id),
                vc.GetNutrients(g.Product4Id),
                vc.GetNutrients(g.Product5Id)
            };
            WeightValues = new int[]
            {
                g.Weight1,
                g.Weight2,
                g.Weight3,
                g.Weight4,
                g.Weight5
            };
        }
    }

    public class PassedObject
    {
        public Voedingswaarden[] products;
        public int[] weights;
    }
}
