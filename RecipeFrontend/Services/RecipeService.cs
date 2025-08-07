using Microsoft.AspNetCore.Components.Forms;
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

        public async Task AddRecipeAsync(RecipeCreateDto newRecipe, IBrowserFile? selectedImage)
        {

            var form = new MultipartFormDataContent();

            form.Add(new StringContent(newRecipe.Title), "Title");
            form.Add(new StringContent(newRecipe.Description), "Description");
            form.Add(new StringContent(newRecipe.CategoryId.ToString()), "CategoryId");
            form.Add(new StringContent("1"), "UserId");

            //Add ingredients to the form
            if (newRecipe.Ingredients != null)
            {
                for (int i = 0; i< newRecipe.Ingredients.Count; i++)
                {
                    form.Add(new StringContent(newRecipe.Ingredients[i].Name), $"Ingredients[{i}].Name");
                    form.Add(new StringContent(newRecipe.Ingredients[i].Quantity), $"Ingredients[{i}].Quantity");
                }
            }

            //Add steps to the form
            if (newRecipe.Steps != null)
            {
                for (int i = 0; i < newRecipe.Steps.Count; i++)
                {
                    form.Add(new StringContent(newRecipe.Steps[i].Order.ToString()), $"Steps[{i}].Order");
                    form.Add(new StringContent(newRecipe.Steps[i].Instruction), $"Steps[{i}].Instruction");
                }
            }
            if (selectedImage != null)
            {
                var stream = selectedImage.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);
                form.Add(new StreamContent(stream), "Image", selectedImage.Name);
            }

            var response = await _http.PostAsync("api/recipes", form);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Failed to add recipe: {errorMessage}");
            }
        }

        public async Task DeleteRecipe(int id)
        {
            var response = await _http.DeleteAsync($"api/recipes/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Failed to delete recipe: {errorMessage}");
            }
        }

        public async Task UpdateRecipeAsync(int id, RecipeUpdateDTO updateRecipe)
        {

            var form = new MultipartFormDataContent();

            form.Add(new StringContent(updateRecipe.Title), "Title");
            form.Add(new StringContent(updateRecipe.Description), "Description");
            form.Add(new StringContent(updateRecipe.CategoryId.ToString()), "CategoryId");
            form.Add(new StringContent("1"), "UserId");

            //Add ingredients to the form
            if (updateRecipe.Ingredients != null)
            {
                for (int i = 0; i < updateRecipe.Ingredients.Count; i++)
                {
                    form.Add(new StringContent(updateRecipe.Ingredients[i].Name), $"Ingredients[{i}].Name");
                    form.Add(new StringContent(updateRecipe.Ingredients[i].Quantity), $"Ingredients[{i}].Quantity");
                }
            }

            //Add steps to the form
            if (updateRecipe.Steps != null)
            {
                for (int i = 0; i < updateRecipe.Steps.Count; i++)
                {
                    form.Add(new StringContent(updateRecipe.Steps[i].Order.ToString()), $"Steps[{i}].Order");
                    form.Add(new StringContent(updateRecipe.Steps[i].Instruction), $"Steps[{i}].Instruction");
                }
            }
            //if (selectedImage != null)
            //{
            //    var stream = selectedImage.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);
            //    form.Add(new StreamContent(stream), "Image", selectedImage.Name);
            //}

            var response = await _http.PutAsync($"api/recipes/{id}", form);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Failed to update recipe: {errorMessage}");
            }
        }
        
    }
}
