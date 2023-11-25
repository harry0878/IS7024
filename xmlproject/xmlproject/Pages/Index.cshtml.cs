using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json.Schema;
using InspectionData;
using RatingData;

namespace xmlproject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Task<List<DisplayTable>> displayDataList = getDisplayData();
            List<DisplayTable> displayTables = displayDataList.Result;
            ViewData["DisplayTable"] = displayTables;
        }

        static readonly HttpClient HttpClient = new HttpClient();
        public async Task<List<DisplayTable>> getDisplayData()
        {
            return await Task.Run(() =>
            {
                var task = HttpClient.GetAsync("https://data.cincinnati-oh.gov/resource/rg6p-b3h3.json");
                HttpResponseMessage result = task.Result;
                List<Inspection> inspections = new List<Inspection>();
                if (result.IsSuccessStatusCode)
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    inspections = Inspection.FromJson(jsonString);
                }

                var task_2 = HttpClient.GetAsync("https://raw.githubusercontent.com/harry0878/json/master/ratings.json");
                HttpResponseMessage result_2 = task_2.Result;
                List<Rating> inspections_2 = new List<Rating>();
                if (result_2.IsSuccessStatusCode)
                {
                    Task<string> readString = result_2.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    inspections_2 = Rating.FromJson(jsonString);
                }

                IDictionary<string, Inspection> InspDict = new Dictionary<string, Inspection>();

                foreach (Inspection Inspection in inspections)
                {
                    try
                    {
                        String businessName = Inspection.BusinessName.Replace("\"", "");
                        
                        InspDict[businessName] = Inspection;
                    }
                    catch (Exception ex) { }
                }

                List<DisplayTable> customDataList = new List<DisplayTable>();
                try
                {
                    foreach (Rating Rating in inspections_2)
                    {
                        if (InspDict.ContainsKey(Rating.Name))
                        {
                            DisplayTable customData = new DisplayTable();
                            customData.Name = Rating.Name;
                            customData.Address = InspDict[Rating.Name].Address;
                            customData.PostalCode = Rating.PostalCode;
                            customData.InspType = InspDict[Rating.Name].InspType;
                            customData.PhoneNumber = InspDict[Rating.Name].PhoneNumber;
                            customData.LicenseStatus = InspDict[Rating.Name].LicenseStatus;
                            customData.InspSubtype = InspDict[Rating.Name].InspSubtype;
                            customData.ActionDate = InspDict[Rating.Name].ActionDate.Split('T')[0];
                            customData.ViolationDesc = InspDict[Rating.Name].ViolationDescription;
                            customData.Reviews = Rating.Reviews.Split(' ')[0];
                            customData.NoOfReviews = Rating.NoOfReviews;
                            customDataList.Add(customData);
                        }
                    }
                }
                catch (Exception ex) { }
                return customDataList;
            });
        }
    }
}