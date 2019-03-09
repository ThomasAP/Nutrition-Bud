using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.Models
{
    public class NutritionPlan
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IList<Food> Foods { get; set; }
    }
}
