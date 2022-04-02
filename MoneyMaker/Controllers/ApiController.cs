using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;
using MoneyMaker.Models;
using MoneyMaker.Services;

namespace MoneyMaker.Controllers;

    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private ApiService apiService;
        private CurrencyService currencyService;
        private AlertService alertService;
        private PortfolioService portfolioService;
        private readonly UserManager<IdentityUser> _userManager;

        private string LOCAL_CURRENCY = "CAD";

        public ApiController(
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

        // GET api/currencies
        [HttpGet("currencies")]
        [AllowAnonymous]
        public async Task<IEnumerable<Currency>> getCurrencies()
        {
            return await currencyService.GetCurrencies();
        }

        // GET api/convert?from=&to=
        [HttpGet("convert")]
        [AllowAnonymous]
        public async Task<Dictionary<string, string>> getConvert(
            [FromQuery(Name = "from")] string fromCurrency,
            [FromQuery(Name = "to")] string toCurrency)
        {
            Dictionary<string, string> conversionResult = new Dictionary<string, string>();
            float data = await apiService.GetRate(fromCurrency, toCurrency);
            
            conversionResult.Add("data", data.ToString());
            conversionResult.Add("from", fromCurrency);
            conversionResult.Add("to", toCurrency);

            return conversionResult;
        }

        // GET api/chart?from=&to=
        [HttpGet("chart")]
        [AllowAnonymous]
        public async Task<Dictionary<string, float>> getChart(
            [FromQuery(Name = "from")] string fromCurrency,
            [FromQuery(Name = "to")] string toCurrency)
        {
            return await apiService.GetMonthRate(fromCurrency, toCurrency);
        }

        
        //=====================================
        // Alert
        //=====================================
        // GET api/alert
        [HttpGet("alert")]
        [AllowAnonymous]
        public async Task<IEnumerable<Alert>> getUserAlert(
            [FromQuery(Name = "userid")] string userid)
        {
            return await alertService.GetUserAlerts(userid);
        }



        //=====================================
        // Portfolio
        //=====================================
        // GET api/portfolio
        [HttpGet("portfolio")]
        [AllowAnonymous]
        public async Task<IEnumerable<PortfolioEntry>> getUserPortfolio(
            [FromQuery(Name = "userid")] string userid)
        {
            return await portfolioService.GetUserPortfolio(userid);
        }


    }
