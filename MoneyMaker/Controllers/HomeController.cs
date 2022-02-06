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
        private const string BASE_URL = "https://api.exchangerate.host/latest";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public async Task<IActionResult> Index(int fromValue, String fromUnit, String toUnit)
        // {
        //     var message = new HttpRequestMessage();
        //     message.Method = HttpMethod.Get;

        //     string url = BASE_URL + "?base=" + fromUnit + "&symbols=" + toUnit;
        //     message.RequestUri = new Uri(url);
        //     message.Headers.Add("Accept", "application/json");

        //     var client = _clientFactory.CreateClient();

        //     var response = await client.SendAsync(message);

        //     if (response.IsSuccessStatusCode)
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();
                
        //         Console.WriteLine("ok");
        //         //Students = await JsonSerializer.DeserializeAsync<IEnumerable<Student>>(responseStream);
        //     }
        //     else
        //     {
        //         //GetStudentsError = true;
        //         //Students = Array.Empty<Student>();
        //     }

        //     return View();
        // }

        [HttpGet]
    public async Task<ActionResult> Index()
    {
        using (var client = new HttpClient())
        {
            string url = BASE_URL + "?base=USD&symbols=CAD";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsondata = await response.Content.ReadAsStringAsync();
                return Content(jsondata, "application/json");
            }
            return View();
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