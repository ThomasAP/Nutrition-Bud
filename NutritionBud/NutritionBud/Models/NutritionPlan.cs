using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.Models
{
    public class NutritionPlan
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlanId { get; set; }

        private static int nextId = 1;


        public NutritionPlan()
        {
            PlanId = nextId;
            nextId++;
        }
    }
}
