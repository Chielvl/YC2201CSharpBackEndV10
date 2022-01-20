using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerechtController : ControllerBase
    {
        int hoeveelheidIngredienten;

        DatabaseContext databaseContext;
        ProductenController productenController;
        VoedingswaardenController voedingswaardenController;
        Voedingswaarden voedingswaardenTotaal;

        private Product[] ingredienten;
        private int[] gewichtWaarden;

        public GerechtController(DatabaseContext dbContext)
        {
            databaseContext = dbContext;
            productenController = new ProductenController(dbContext);
            voedingswaardenController = new VoedingswaardenController(dbContext);
            voedingswaardenTotaal = new Voedingswaarden();
        }

        [HttpGet("{receptNaam}/{receptOmschrijving}/{ingredient1}/{gewicht1}/{ingredient2}/{gewicht2}/{ingredient3}/{gewicht3}/{ingredient4}/{gewicht4}/{ingredient5}/{gewicht5}")]
        public Gerecht SetGerecht(string receptNaam, string receptOmschrijving, int ingredient1, int ingredient2, int ingredient3, int ingredient4, int ingredient5, int gewicht1, int gewicht2, int gewicht3, int gewicht4, int gewicht5)
        {
            Gerecht gerecht = new Gerecht();
            gerecht.Naam = receptNaam;
            gerecht.Omschrijving = receptOmschrijving;
            gerecht.Ingredient1Id = ingredient1;
            gerecht.Ingredient2Id = ingredient2;
            gerecht.Ingredient3Id = ingredient3;
            gerecht.Ingredient4Id = ingredient4;
            gerecht.Ingredient5Id = ingredient5;
            gerecht.Gewicht1 = gewicht1;
            gerecht.Gewicht2 = gewicht2;
            gerecht.Gewicht3 = gewicht3;
            gerecht.Gewicht4 = gewicht4;
            gerecht.Gewicht5 = gewicht5;
            databaseContext.Add(gerecht);
            databaseContext.SaveChanges();
            return gerecht;
        }

        [HttpGet("{gerechtId}")]
        public string GetGerecht(int gerechtId)
        {

            var gerecht = databaseContext.Find<Gerecht>(gerechtId);
            if (gerecht != null)
            {
                string msg = $"In het gerecht {gerecht.Naam} zit:" + Environment.NewLine;
                string ingredient1 = productenController.GetProduct(gerecht.Ingredient1Id).Naam;
                msg += $"{gerecht.Gewicht1} gram {ingredient1}" + Environment.NewLine;
                string ingredient2 = productenController.GetProduct(gerecht.Ingredient2Id).Naam;
                msg += $"{gerecht.Gewicht2} gram {ingredient2}" + Environment.NewLine;
                hoeveelheidIngredienten = 2;
                if (gerecht.Gewicht3 != 0)
                {
                    hoeveelheidIngredienten = 3;
                    string ingredient3 = productenController.GetProduct(gerecht.Ingredient3Id).Naam;
                    msg += $"{gerecht.Gewicht3} gram {ingredient3}" + Environment.NewLine;
                    if (gerecht.Gewicht4 != 0)
                    {
                        hoeveelheidIngredienten = 4;
                        string ingredient4 = productenController.GetProduct(gerecht.Ingredient4Id).Naam;
                        msg += $"{gerecht.Gewicht4} gram {ingredient4}" + Environment.NewLine;
                        if (gerecht.Gewicht5 != 0)
                        {
                            hoeveelheidIngredienten = 5;
                            string ingredient5 = productenController.GetProduct(gerecht.Ingredient5Id).Naam;
                            msg += $"{gerecht.Gewicht5} gram {ingredient5}" + Environment.NewLine;
                        }
                    }
                }
                return msg;
            }
            return "Onbekend";
        }

        [HttpGet("Ingredienten/{gerechtId}")]
        public Voedingswaarden ingredientenLijst(int gerechtId)
        {
            GetGerecht(gerechtId);
            var gerecht = databaseContext.Find<Gerecht>(gerechtId);
            ingredienten = new Product[hoeveelheidIngredienten];
            gewichtWaarden = new int[hoeveelheidIngredienten];
            ingredienten[0] = productenController.GetProduct(gerecht.Ingredient1Id);
            gewichtWaarden[0] = gerecht.Gewicht1;
            ingredienten[1] = productenController.GetProduct(gerecht.Ingredient2Id);
            gewichtWaarden[1] = gerecht.Gewicht2;
            if (gerecht.Gewicht3 != 0)
            {
                ingredienten[2] = productenController.GetProduct(gerecht.Ingredient3Id);
                gewichtWaarden[2] = gerecht.Gewicht3;
                if (gerecht.Gewicht4 != 0)
                {
                    ingredienten[3] = productenController.GetProduct(gerecht.Ingredient4Id);
                    gewichtWaarden[3] = gerecht.Gewicht4;
                    if (gerecht.Gewicht5 != 0)
                    {
                        ingredienten[4] = productenController.GetProduct(gerecht.Ingredient5Id);
                        gewichtWaarden[4] = gerecht.Gewicht5;
                    }

                }
            }
            return VoedingswaardenTotaal(ingredienten);
        }

        public Voedingswaarden VoedingswaardenTotaal(Product[] ingredientenLijst)
        {
            for (int p = 0; p < ingredientenLijst.Length; p++)
            {
                Voedingswaarden productVW = voedingswaardenController.GetVoedingswaarden(ingredientenLijst[p].VoedingswaardenId);
                voedingswaardenTotaal.EnergieKcal += productVW.EnergieKcal * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.EnergieKj += productVW.EnergieKj * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.Water += productVW.Water * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.Eiwit += productVW.Eiwit * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.Koolhydraten += productVW.Koolhydraten * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.Suikers += productVW.Suikers * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.Vet += productVW.Vet * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.VerzadigdVet += productVW.VerzadigdVet * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.EnkelvoudigVerzadigd += productVW.EnkelvoudigVerzadigd * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.MeervoudigVerzadigd += productVW.MeervoudigVerzadigd * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.Cholesterol += productVW.Cholesterol * (gewichtWaarden[p] / 100);
                voedingswaardenTotaal.VoedingsVezels += productVW.VoedingsVezels * (gewichtWaarden[p] / 100);
            }

            return voedingswaardenTotaal;
        }
    }
}
