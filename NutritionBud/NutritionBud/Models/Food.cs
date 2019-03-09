using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.Models
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }        

        public int NutritionPlanID { get; set; }
        public NutritionPlan NutritionPlan { get; set; }
    }
}
