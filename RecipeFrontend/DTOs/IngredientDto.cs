using System.ComponentModel.DataAnnotations;

namespace RecipeFrontend.DTOs
{
    public class IngredientDto
    {
        [Required(ErrorMessage = "Ingredient name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingredient quantity is required.")]
        public string Quantity { get; set; } = string.Empty;
    }
}
