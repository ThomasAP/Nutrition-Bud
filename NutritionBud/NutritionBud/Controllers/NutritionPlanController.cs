using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionBud.Models;
using NutritionBud.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NutritionBud.Controllers
{
    public class NutritionPlanController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<NutritionPlan> nutritionPlans = NutritionPlanData.nutritionPlans;
            return View(nutritionPlans);
        }

        //TODO: Handler for Add 
        public IActionResult Add()
        {
            AddNutritionPlanViewModel addNutritionPlanViewModel = new AddNutritionPlanViewModel();
            return View(addNutritionPlanViewModel);
        }

        //TODO: Handler for Add (HttpPost)
        [HttpPost]
        public IActionResult Add(AddNutritionPlanViewModel addNutritionPlanViewModel)
        {
            if (ModelState.IsValid)
            {
                NutritionPlan newNutritionPlan = new NutritionPlan
                {
                    Name = addNutritionPlanViewModel.Name,
                    Description = addNutritionPlanViewModel.Description
                };

                NutritionPlanData.Add(newNutritionPlan);

                return Redirect("/NutritionPlan");
            }

            return View(addNutritionPlanViewModel);

        }

        //TODO: Handler for Remove
        public IActionResult Remove()
        {
            ViewBag.Title = "Remove Nutrition Plans";
            ViewBag.nutritionPlans = NutritionPlanData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] nutritionPlanIds)
        {
            //TODO: Remove foods from list
            foreach (int nutritionPlanId in nutritionPlanIds)
            {
                NutritionPlanData.Remove(nutritionPlanId);
            }


            return Redirect("/NutritionPlan");
        }
    }
}