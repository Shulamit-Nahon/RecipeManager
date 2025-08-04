namespace RecipeFrontend.DTOs
{
    public class IngredientUpdateDto
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;
    }
}
