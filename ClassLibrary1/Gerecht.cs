using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Gerecht
    { 
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Omschrijving { get; set; }
    public int Ingredient1Id { get; set; }
    public int Ingredient2Id { get; set; }
    public int Ingredient3Id { get; set; }
    public int Ingredient4Id { get; set; }
    public int Ingredient5Id { get; set; }
    public int Gewicht1 { get; set; }
    public int Gewicht2 { get; set; }
    public int Gewicht3 { get; set; }
    public int Gewicht4 { get; set; }
    public int Gewicht5 { get; set; }

    public string GerechtOproepen()
    {
        string msg = "";
        for (int i = 0; i < 5;)
        {
            //              if(receptArray[0, i] == 0 || receptArray[1, i] == 0)
            //            {
            //              msg += "Geen ingredient of gewicht opgegeven";
            //            break;
            //      }
            //    msg += $"Ingredient {i} heeft id {receptArray[0, i]}, in {receptArray[1, i]} grammen" + Environment.NewLine;
            i++;
        }

        return msg;
    }

}
}
