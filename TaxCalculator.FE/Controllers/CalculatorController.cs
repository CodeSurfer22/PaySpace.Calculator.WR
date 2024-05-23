using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.PointsToAnalysis;
using Newtonsoft.Json;
using System.Diagnostics;
using TaxCalculator.FE.Models;

namespace TaxCalculator.FE.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public CalculatorController(ILogger<CalculatorController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index(string? postalCode, decimal annualSalary)
        {
            List<Calculations_History> taxes = new List<Calculations_History>();
            // Use the HttpClientFactory to create a new HttpClient
            var client = _httpClientFactory.CreateClient();

            try
            {

                // Make a request to the Web API's Get endpoint with the price parameter
                var response = await client.GetAsync($"http://localhost:5245/api/TaxCalculations?postalCode=" + postalCode + "&" + "annualSalary=" + annualSalary);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    taxes = JsonConvert.DeserializeObject<List<Calculations_History>>(jsonString);
                }
                else
                {
                    // Log error or handle different response statuses as needed
                    ViewBag.ErrorMessage = "Error retrieving data from the Web API";
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle it as needed
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return View(taxes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}