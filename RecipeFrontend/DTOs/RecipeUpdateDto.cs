namespace RecipeFrontend.DTOs
{
    public class RecipeUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public List<IngredientDto> Ingredients { get; set; } = new();
        public List<StepDto> Steps { get; set; } = new();

        //public IFormFile? File { get; set; } // Optional replacement file
        public bool RemoveExistingFile { get; set; } = false;
    }
}
