using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionBud.Data;
using NutritionBud.Models;
using NutritionBud.ViewModels;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NutritionBud.Controllers
{
    public class NutritionPlanController : Controller
    {

        private NutritionPlanDbContext context;
        
        // GET: /<controller>/

        public  NutritionPlanController(NutritionPlanDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<NutritionPlan> nutritionPlans = context.NutritionPlans.ToList();
            return View(nutritionPlans);
        }

        
        public IActionResult Add()
        {
            AddNutritionPlanViewModel addNutritionPlanViewModel = new AddNutritionPlanViewModel();
            return View(addNutritionPlanViewModel);
        }

        
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

                context.NutritionPlans.Add(newNutritionPlan);
                context.SaveChanges();

                return Redirect("/NutritionPlan");
            }

            return View(addNutritionPlanViewModel);

        }

        
        public IActionResult Remove()
        {
            ViewBag.Title = "Remove Nutrition Plans";
            ViewBag.nutritionPlans = context.NutritionPlans.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] nutritionPlanIds)
        {
            //TODO: Remove foods from list
            foreach (int nutritionPlanId in nutritionPlanIds)
            {
                NutritionPlan thePlan = context.NutritionPlans.Single(n => n.ID == nutritionPlanId);
                context.NutritionPlans.Remove(thePlan);
            }

            context.SaveChanges();


            return Redirect("/NutritionPlan");
        }
    }
}