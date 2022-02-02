using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Voedingswaarden
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int EnergieKcal { get; set; }         //in kcal
        public int EnergieKj { get; set; }           //in kilo joule
        public int Water { get; set; }              //in grammen
        public int Eiwit { get; set; }              //in grammen
        public int Koolhydraten { get; set; }       //in grammen
        public int Suikers { get; set; }            //in grammen
        public int Vet { get; set; }                //in grammen
        public int VerzadigdVet { get; set; }       //in grammen
        public int EnkelvoudigVerzadigd { get; set; } //in grammen
        public int MeervoudigVerzadigd { get; set; } //in grammen
        public int Cholesterol { get; set; }        //in milligrammen
        public int VoedingsVezels { get; set; }     //in grammen
        public int Alcohol { get; set; }             //in grammen

        public Voedingswaarden(int energieKcal, int energieKj, int Water, int eiwit, int koolhydraten, int suikers, int vet, int verzadigdVet, int enkelvoudigVerzadigd, int meervoudigVerzadigd, int cholesterol, int voedingsVezels, int alcohol)
        {

            if (energieKcal == 0 && energieKj != 0)                   // als energie in kj niet is ingevuld, maar energie in kcal wel, bereken kj
                energieKcal = (int)((double)energieKj / 4.2);
            else if (energieKj == 0 && energieKcal != 0)              // als energie in kcal niet is ingevuld, maar energie in kj wel, bereken kcal
                energieKj = (int)((double)energieKcal * 4.2);
            else if (energieKj == 0 && energieKcal == 0)              // als allebei niet zijn ingevuld
            {
                this.EnergieKcal = BerekenEnergieWaarde(vet, koolhydraten, eiwit, voedingsVezels, alcohol);
                energieKj = (int)((double)energieKcal * 4.2);        //berekend kj op basis van kcal
            }   

            this.EnergieKcal = energieKcal;
            this.EnergieKj = energieKj;
            this.Water = Water;
            this.Eiwit = eiwit;
            this.Koolhydraten = koolhydraten;
            this.Suikers = suikers;
            this.Vet = vet;
            this.VerzadigdVet = verzadigdVet;
            this.EnkelvoudigVerzadigd = enkelvoudigVerzadigd;
            this.MeervoudigVerzadigd = meervoudigVerzadigd;
            this.Cholesterol = cholesterol;
            this.VoedingsVezels = voedingsVezels;
            this.Alcohol = alcohol;
        }
        public Voedingswaarden()
        { }

        int BerekenEnergieWaarde(int vet, int koolhydraten, int eiwit, int voedingsVezels, int alcohol)         
        {   
            int berekendeEnergieInKcal = 0;                     //bron: https://www.voedingswaardetabel.nl/watiswat/energie/
            berekendeEnergieInKcal += (vet * 9);
            berekendeEnergieInKcal += (koolhydraten * 4);
            berekendeEnergieInKcal *= (eiwit * 4);
            berekendeEnergieInKcal *= (voedingsVezels * 4);
            berekendeEnergieInKcal += (alcohol * 7);

            return berekendeEnergieInKcal;
        }
    }
}
