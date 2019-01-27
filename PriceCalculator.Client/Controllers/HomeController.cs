using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PriceCalculator.Client.Models;
using PriceCalculator.Model;

namespace PriceCalculator.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<Backend> appSettings;

        public HomeController(IOptions<Backend> app)
        {
            appSettings = app;
        }

        public IActionResult Index()
        {
            var model = new PriceRequest();
            return View(model);
        }

        public IActionResult PriceCal(PriceRequest model)
        {
            var requestUrl = appSettings.Value.WebApiBaseUrl;
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var result = client.PostAsync(requestUrl, content).Result;
            var Price = result.Content.ReadAsStringAsync().Result;

            //return View(result);
            //var result = new PriceResponse() { TotalPrice = 1000, Reason = "test" };
            return View(JsonConvert.DeserializeObject<PriceResponse>(Price));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
