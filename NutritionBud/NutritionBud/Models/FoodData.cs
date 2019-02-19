using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.Models
{
    public class FoodData
    {
        static public List<Food> foods = new List<Food>();
        

        // Get All
        public static List<Food> GetAll()
        {
            return foods;
        }


        //Add
        public static void Add(Food newFood)
        {
            foods.Add(newFood);
        }


        //Remove
        public static void Remove(int id)
        {
            Food foodToRemove = GetById(id);
            foods.Remove(foodToRemove);
        }

       


        //GetById
        public static Food GetById(int id)
        {
            return foods.Single(x => x.FoodId == id);
        }
    }
}
