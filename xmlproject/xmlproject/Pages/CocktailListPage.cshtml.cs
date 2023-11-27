using JSONDataModelCocktail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace xmlproject.Pages
{
    public class CocktailListPageModel : PageModel
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        public void OnGet()
        {
            Task<CocktailDataModel> cocktailDetails = GetCocktailDetails();
            CocktailDataModel recipeList = cocktailDetails.Result;
            ViewData["Cocktaillist"] = recipeList;
        }

        private async Task<CocktailDataModel> GetCocktailDetails()
        {
            return await Task.Run(async () =>
            {
                var config = new ConfigurationBuilder()
                    .AddUserSecrets<Program>()
                    .Build();

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://nutrizen.azurewebsites.net/v1/api/values"),

                };
                CocktailDataModel cocktailData;
                var response = await HttpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                cocktailData = CocktailDataModel.FromJson(body);
                return cocktailData;

            });
        }
    }
}
