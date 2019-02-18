using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.Models
{
    public class Food
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double FoodId { get; set; }
        private static int nextId = 1;

        public Food(string name, double price)
        {
            Name = name;
            Price = price;
            FoodId = nextId;
            nextId++;
        }

        public Food() {
            FoodId = nextId;
            nextId++;
        }
    }
}
