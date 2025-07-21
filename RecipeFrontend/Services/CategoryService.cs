using RecipeFrontend.DTOs;
using System.Net.Http.Json;

namespace RecipeFrontend.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories");
            return categories ?? new List<CategoryDto>();
        }
    }
}
