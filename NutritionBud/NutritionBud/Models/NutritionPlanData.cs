using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.Models
{
    public class NutritionPlanData
    {
        public static List<NutritionPlan> nutritionPlans = new List<NutritionPlan>();

        // Get All
        public static List<NutritionPlan> GetAll()
        {
            return nutritionPlans;
        }


        //Add
        public static void Add(NutritionPlan newPlan)
        {
            nutritionPlans.Add(newPlan);
        }


        //Remove
        public static void Remove(int id)
        {
            NutritionPlan nutritionPlanToRemove = GetById(id);
            nutritionPlans.Remove(nutritionPlanToRemove);
        }




        //GetById
        public static NutritionPlan GetById(int id)
        {
            return nutritionPlans.Single(x => x.NutritionPlanId == id);
        }
    }
}
