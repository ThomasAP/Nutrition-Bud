using Microsoft.AspNetCore.Mvc.Rendering;
using NutritionBud.Data;
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

        //Property to represent the Nutrition Plan that user will choose
        [Display(Name = "Nutrition Plan")]
        public int NutritionPlanID { get; set; }

        public List<SelectListItem> NutritionPlans { get; set; }


        public AddFoodViewModel(IEnumerable<NutritionPlan> nutritionPlans)
        {
            NutritionPlans = new List<SelectListItem>();

            foreach (NutritionPlan plan in nutritionPlans)
            {
                NutritionPlans.Add(new SelectListItem
                {
                    Value = plan.ID.ToString(),
                    Text = plan.Name.ToString()
                });
            }

        }
        public AddFoodViewModel() { }
    }
}
