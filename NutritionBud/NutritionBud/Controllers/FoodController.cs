using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NutritionBud.Controllers
{
    public class FoodController : Controller
    {
        //Controller list to hold Foods until Database is running
        static private List<string> Foods = new List<string>();

        // GET: /<controller>/
        public IActionResult Index()
        {           
            ViewBag.foods = Foods;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            //Add new food to foods
            Foods.Add(name);

            return Redirect("/Food");
        }
    }
}
