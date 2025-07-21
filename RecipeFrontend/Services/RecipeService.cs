using RecipeFrontend.DTOs;
using System.Net.Http.Json;

namespace RecipeFrontend.Services
{
    public class RecipeService
    {
        private readonly HttpClient _http;

        public RecipeService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RecipeDto>> GetAllRecipesAsync()
        {
            var recipes = await _http.GetFromJsonAsync<List<RecipeDto>>("api/recipes");
            return recipes ?? new List<RecipeDto>();
        }

        public async Task<RecipeDto?> GetRecipeByIdAsync(int id)
        {
            var recipe = await _http.GetFromJsonAsync<RecipeDto>($"api/recipes/{id}");
            return recipe;
        }

        public async Task AddRecipeAsync(RecipeCreateDto newRecipe)
        {
            var response = await _http.PostAsJsonAsync("api/recipes", newRecipe);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Failed to add recipe: {errorMessage}");
            }
        }
    }
}
