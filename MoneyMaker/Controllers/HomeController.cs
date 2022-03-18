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
        private AlertService alertService;
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
            alertService = new AlertService(context);
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currList = await currencyService.GetCurrencies();
            ViewBag.currencies = currList;
            ViewBag.alerts = await getUserAlert();
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
                ViewBag.alerts = await getUserAlert();

                var chartData = await apiService.GetMonthRate(model.FromCurrency, model.ToCurrency);
                model.ChartData = chartData;
                return View(model);
            }else{
                // Response ERROR
                return View();
            }
        }

        private async Task<IEnumerable<Alert>> getUserAlert()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(User);
            return await alertService.GetUserAlerts(id);
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