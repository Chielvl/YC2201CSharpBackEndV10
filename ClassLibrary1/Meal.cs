using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int MealType { get; set; }
        public DateTime DateTime { get; set; }
        public int MealsDishComponentsId { get; set; }
        public int NutrientsId { get; set; }
        public string Notes { get; set; }

        private Voedingswaarden[] Nutrients { get; set; }
        private Gerecht[] Dishes { get; set; }

        DatabaseContext dbc;

        public Meal (int Id, string Name, int UserId,int MealType, DateTime DateTime,int MealsDishComponentsId, int NutrientsId)
        {
            this.Id = Id;
            this.Name = Name;
            this.UserId = UserId;
            this.MealType = MealType;
            this.DateTime = DateTime;
            this.MealsDishComponentsId = MealsDishComponentsId;
            this.NutrientsId = NutrientsId;
        }

        public Meal()
        {

        }
    }
}
