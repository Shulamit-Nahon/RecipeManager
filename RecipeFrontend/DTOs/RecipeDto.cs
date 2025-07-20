namespace RecipeFrontend.DTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Flattened category
        public string CategoryName { get; set; } = string.Empty;

        // Ingredients as name+quantity only
        public List<IngredientDto> Ingredients { get; set; } = new();

        // Ordered steps
        public List<StepDto> Steps { get; set; } = new();

        // Optional file
        public string? FilePath { get; set; }

        // Created by
        public string UserFullName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
