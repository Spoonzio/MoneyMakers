#nullable disable
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Models;
using MoneyMaker.Data;
using System.Diagnostics;

using MoneyMaker.Services;
using MoneyMaker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace MoneyMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApiService apiService;
        private CurrencyService currencyService;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context,
            IHttpClientFactory httpClientFactory,
            UserManager<IdentityUser> userManager
            )
        {
            _logger = logger;
            apiService = new ApiService(httpClientFactory);
            currencyService = new CurrencyService(context);
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currList = await currencyService.GetCurrencies();
            ViewBag.currencies = currList;
            return View(new ConvertViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(ConvertViewModel model)
        {   
            if(model.FromValue <= 0) model.FromValue = 1;

            // Get rate from service
            // External API -> Api Service -> THIS
            float rate = await apiService.GetRate(model.FromCurrency, model.ToCurrency);

            if (rate>0){
                // Response SUCCESS
                model.ToValue = rate * model.FromValue;
                var currList = await currencyService.GetCurrencies();
                ViewBag.currencies = currList;

                var chartData = await apiService.GetMonthRate(model.FromCurrency, model.ToCurrency);
                model.ChartData = chartData;
                return View(model);
            }else{
                // Response ERROR
                return View();
            }
        }

        public async Task<IActionResult> AddAlert(string toCurr, string fromCurr, float currVal)
        {

            var alert = new Alert();
            alert.FromCurrency = fromCurr;
            alert.ToCurrency = toCurr;
            alert.ConditionValue = currVal;
            alert.isBelow = false;
            alert.CreateDate = DateTime.Today;
            
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(User); // Get user id:
            alert.UserId = id;

            var currList = await currencyService.GetCurrencies();
            ViewBag.currencies = currList;

            return View("~/Views/Alert/Create.cshtml", alert);
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