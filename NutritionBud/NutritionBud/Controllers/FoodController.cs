using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionBud.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NutritionBud.Controllers
{
    public class FoodController : Controller
    {
        //Controller list to hold Foods until Database is running
        

        // GET: /<controller>/
        public IActionResult Index()
        {         
            //TODO: Look into using JSON to persist data before getting to database (or even as an alternative)
            ViewBag.foods = FoodData.foods;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string name, double price)
        {
            //Add new food to foods
            Food newFood = new Food
            {
                Name = name,
                Price = price
            };

            FoodData.Add(newFood);

            return Redirect("/Food");
        }

        public IActionResult Remove()
        {
            ViewBag.Title = "Remove Foods";
            ViewBag.foods = FoodData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] foodIds)
        {
            //TODO: Remove foods from list
            foreach (int foodId in foodIds)
            {               
                FoodData.Remove(foodId);
            }
            

            return Redirect("/");
        }
    }
}
