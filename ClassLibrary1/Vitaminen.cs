using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Vitaminen
    {   
        public int Id { get; set; }
        public string Naam { get; set; }
        public float VitamineA { get; set; }              //in milligrammen
        public float VitamineB1 { get; set; }             //in milligrammen
        public float VitamineB2 { get; set; }             //in milligrammen
        public float VitamineB3 { get; set; }             //in milligrammen
        public float VitamineB6 { get; set; }             //in milligrammen
        public float VitamineB11 { get; set; }            //in microgrammen
        public float VitamineB12 { get; set; }            //in microgrammen
        public float VitamineC { get; set; }              //in milligrammen
        public float VitamineD { get; set; }              //in microgrammen
        public float VitamineE { get; set; }              //in milligrammen
        public float VitamineK { get; set; }              //in microgrammen            

        public Vitaminen(float EnergVitamineAyKcal, float VitamineB1, float VitamineB2, float VitamineB3, float VitamineB6, float VitamineB11, float VitamineB12, float VitamineC, float VitamineD, float VitamineE, float VitamineK)
        {
            this.VitamineA = VitamineA;
            this.VitamineB1 = VitamineB1;
            this.VitamineB2 = VitamineB2;
            this.VitamineB3 = VitamineB3;
            this.VitamineB6 = VitamineB6;
            this.VitamineB11 = VitamineB11;
            this.VitamineB12 = VitamineB12;
            this.VitamineC = VitamineC;
            this.VitamineD = VitamineD;
            this.VitamineE = VitamineE;
            this.VitamineK = VitamineK;
        }
    }
}
