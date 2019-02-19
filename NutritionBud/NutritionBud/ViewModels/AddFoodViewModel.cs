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

        
    }
}
