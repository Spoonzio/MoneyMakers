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
        private PortfolioService portfolioService;
        private readonly UserManager<IdentityUser> _userManager;

        private string LOCAL_CURRENCY = "CAD";

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
            portfolioService = new PortfolioService(context);
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.currencies = await currencyService.GetCurrencies();
            ViewBag.alerts = await getUserActiveAlert();
            ViewBag.portfolioEntry = await getUserPortfolioEntry();
            ViewBag.PortfolioTotal = await getUserPortfolioSum();
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

                ViewBag.currencies = await currencyService.GetCurrencies();
                ViewBag.alerts = await getUserActiveAlert();
                ViewBag.portfolioEntry = await getUserPortfolioEntry();
                ViewBag.PortfolioTotal = await getUserPortfolioSum();

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

        private async Task<IEnumerable<Alert>> getUserActiveAlert()
        {
            var userAlerts = await getUserAlert();
            List<Alert> userActiveAlerts = new List<Alert>();

            foreach (var alert in userAlerts)
            {
                var currValue = await apiService.GetRate(alert.FromCurrency, alert.ToCurrency);

                if (alert.isBelow && currValue < alert.ConditionValue)
                {
                    userActiveAlerts.Add(alert);
                }
                else if (!alert.isBelow && currValue > alert.ConditionValue)
                {
                    userActiveAlerts.Add(alert);
                }
            }

            return userActiveAlerts;
        }

        private async Task<IEnumerable<PortfolioEntry>> getUserPortfolioEntry()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(User);

            var userPortfolio = await portfolioService.GetUserPortfolio(id);
            return userPortfolio;
        }

        private async Task<string> getUserPortfolioSum()
        {
            float sum = 0;
            var portfolios = await getUserPortfolioEntry();
            List<PortfolioEntry> portfolioEntries = portfolios.ToList();
            foreach (var portfolioEntry in portfolioEntries)
            {
                var rate = await apiService.GetRate(portfolioEntry.EntryCurrencySym, LOCAL_CURRENCY);
                float subTotal = rate * portfolioEntry.EntryValue;

                sum += subTotal;
            }
            return sum.ToString("0.00");
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