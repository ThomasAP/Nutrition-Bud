using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutritionBud.Data;
using NutritionBud.Models;
using NutritionBud.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NutritionBud.Controllers
{
    public class FoodController : Controller
    {

        private NutritionPlanDbContext context;

        //Receive a database instance from Startup.CS service 
        public FoodController(NutritionPlanDbContext dbContext)
        {
            //store database instance in "context"
            context = dbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {         
            //Receive a database item from the dbSet "Foods" in NutritionPlanDbContext, convert it to a list, and store it in "foods"
            List<Food> foods = context.Foods.Include(f => f.NutritionPlan).ToList();

            return View(foods);
        }

        public IActionResult Add()
        {
            AddFoodViewModel addFoodViewModel = new AddFoodViewModel(context.NutritionPlans.ToList());
            return View(addFoodViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddFoodViewModel addFoodViewModel)
        {
            if(ModelState.IsValid)
            {
                NutritionPlan newNutritionPlan = context.NutritionPlans.Single(p => p.ID == addFoodViewModel.NutritionPlanID);
                //Add new food to context and save it
                Food newFood = new Food
                {
                    Name = addFoodViewModel.Name,
                    Price = addFoodViewModel.Price,
                    NutritionPlan = newNutritionPlan
                };

                context.Foods.Add(newFood);
                context.SaveChanges();

                return Redirect("/Food");
            }
            return View(addFoodViewModel);
           
        }

        public IActionResult Remove()
        {
            ViewBag.Title = "Remove Foods";
            ViewBag.foods = context.Foods.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] foodIds)
        {
            //TODO: Remove foods from list
            foreach (int foodId in foodIds)
            {
                Food theFood = context.Foods.Single(f => f.ID == foodId);
                context.Foods.Remove(theFood);
            }

            context.SaveChanges();

            return Redirect("/Food");
        }
    }
}
