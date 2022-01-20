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
        public string Naam { get; set; }
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

        public Voedingswaarden(int EnergieKcal, int EnergieKj, int Water, int Eiwit, int Koolhydraten, int Suikers, int Vet, int VerzadigdVet, int EnkelvoudigVerzadigd, int MeervoudigVerzadigd, int Cholesterol, int VoedingsVezels, int Alcohol)
        {

            if (EnergieKcal == 0 && EnergieKj != 0)                   // als energie in kj niet is ingevuld, maar energie in kcal wel, bereken kj
                EnergieKcal = (int)((double)EnergieKj / 4.2);
            else if (EnergieKj == 0 && EnergieKcal != 0)              // als energie in kcal niet is ingevuld, maar energie in kj wel, bereken kcal
                EnergieKj = (int)((double)EnergieKcal * 4.2);
            else if (EnergieKj == 0 && EnergieKcal != 0)              // als allebei niet zijn ingevuld
            {
                this.EnergieKcal = BerekenEnergieWaarde();
                EnergieKj = (int)((double)EnergieKcal * 4.2);
            }

            this.EnergieKcal = EnergieKcal;
            this.EnergieKj = EnergieKj;
            this.Water = Water;
            this.Eiwit = Eiwit;
            this.Koolhydraten = Koolhydraten;
            this.Suikers = Suikers;
            this.Vet = Vet;
            this.VerzadigdVet = VerzadigdVet;
            this.EnkelvoudigVerzadigd = EnkelvoudigVerzadigd;
            this.MeervoudigVerzadigd = MeervoudigVerzadigd;
            this.Cholesterol = Cholesterol;
            this.VoedingsVezels = VoedingsVezels;
            this.Alcohol = Alcohol;
        }
        public Voedingswaarden()
        { }

        int BerekenEnergieWaarde()
        {
            int berekendeEnergieInKcal = 0;
            berekendeEnergieInKcal += (Vet * 9);
            berekendeEnergieInKcal += (Koolhydraten * 4);
            berekendeEnergieInKcal *= (Eiwit * 4);
            berekendeEnergieInKcal *= (VoedingsVezels * 4);
            berekendeEnergieInKcal += (Alcohol * 7);

            return berekendeEnergieInKcal;
        }
    }
}
