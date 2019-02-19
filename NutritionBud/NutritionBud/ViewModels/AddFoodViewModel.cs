using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.ViewModels
{
    public class AddFoodViewModel
    {
        [Required]
        [Display(Name = "Food Name")]
        public string Name { get; set; }
        public double Price { get; set; }


    }
}
