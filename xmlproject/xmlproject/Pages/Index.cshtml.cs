using InspectionData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Net.Http;
using System.Numerics;

namespace xmlproject.Pages
{
    public class IndexModel : PageModel
    {
        static readonly HttpClient httpClient = new HttpClient();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var task = httpClient.GetAsync("https://data.cincinnati-oh.gov/resource/rg6p-b3h3.json");
            HttpResponseMessage result = task.Result;
            List<Inspection> inspectionsList = new List<Inspection>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                inspectionsList = Inspection.FromJson(jsonString);
            }
            ViewData["Inspections"] = inspectionsList;
            InspectionRepository.allInspectionDetails = inspectionsList;

        }

    }
}
