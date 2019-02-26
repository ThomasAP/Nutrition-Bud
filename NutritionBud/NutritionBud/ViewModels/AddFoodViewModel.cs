using Microsoft.AspNetCore.Mvc.Rendering;
using NutritionBud.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NutritionBud.ViewModels
{
    public class AddFoodViewModel
    {
        [Required]
        [Display(Name = "Food Name")]
        public string Name { get; set; }

        [Range(0, 100)]
        [Display(Name = "Price $")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Please use XX.XX format.")]
        public decimal Price { get; set; }

        public CurrentPlan CurrentPlan { get; set; }

        public List<SelectListItem> AvailablePlans { get; set; }

        public AddFoodViewModel()
        {
            AvailablePlans = new List<SelectListItem>();

            foreach(NutritionPlan plan in NutritionPlanData.nutritionPlans)
            {
                AvailablePlans.Add(new SelectListItem
                {
                    Value = ((string)plan.Name),
                    Text = plan.Name

                });
            }


        }


        
    }
}
