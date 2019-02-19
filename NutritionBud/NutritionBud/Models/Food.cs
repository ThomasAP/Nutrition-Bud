using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.Models
{
    public class Food
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int FoodId { get; set; }
        private static int nextId = 1;


        public Food()
        {
            FoodId = nextId;
            nextId++;
        }
    }
}
