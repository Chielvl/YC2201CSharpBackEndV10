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
        public string Description { get; set; }
        public int Product1Id { get; set; }
        public int Product2Id { get; set; }
        public int Product3Id { get; set; }
        public int Product4Id { get; set; }
        public int Product5Id { get; set; }
        public int Weight1 { get; set; }
        public int Weight2 { get; set; }
        public int Weight3 { get; set; }
        public int Weight4 { get; set; }
        public int Weight5 { get; set; }


        public bool Equals(Gerecht gerecht2)
        {
            if (gerecht2 == null)
                return false;

            if(Id == gerecht2.Id)
                return true;

            if (Product1Id == gerecht2.Product1Id && Product2Id == gerecht2.Product2Id && Product3Id == gerecht2.Product3Id && Product4Id == gerecht2.Product4Id && Product5Id == gerecht2.Product5Id)
                return true;

            return false;
        }

    }

}