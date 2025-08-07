using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RecipeFrontend.DTOs
{
    public class RecipeCreateDto: IValidatableObject
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(250, ErrorMessage = "Description can't exceed 250 characters.")]
        public string Description { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        [MinLength(1, ErrorMessage = "Please add at least one ingredient.")]
        public List<IngredientDto> Ingredients { get; set; } = new();

        [MinLength(1, ErrorMessage = "Please add at least one step.")]
        public List<StepDto> Steps { get; set; } = new();
        public IFormFile? File { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ingredients == null || !Ingredients.Any())
            {
                yield return new ValidationResult("Please add at least one ingredient.", new[] { nameof(Ingredients) });
            }
        }
    }
}
