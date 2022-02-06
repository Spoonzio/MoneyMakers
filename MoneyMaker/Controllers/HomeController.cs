using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MoneyMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string BASE_URL = "https://api.exchangerate.host";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(int fromValue, String fromUnit, String toUnit)
        {
            using (var client = new HttpClient())
            {
                // Build URL for API call
                string url = BASE_URL + "/latest?base=" + fromUnit + "&symbols=" + toUnit;
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // Response OK
                    string jsondata = await response.Content.ReadAsStringAsync();

                    // TODO: get Rate from JSON

                    // TODO: calculate to_value = Rate * from_value 

                    // TODO: pass calculated value to page with ViewData["ToValue"]
                    //          See index.cshtml for ViewData usage


                    return View();
                }else{
                    // Response ERROR
                    return View();
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}