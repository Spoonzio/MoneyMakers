using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;
using MoneyMaker.Models;
using MoneyMaker.Models;
using MoneyMaker.Services;

namespace MoneyMaker.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ILogger<AlertController> _logger;
        private PortfolioService portfolioService;
        private CurrencyService currencyService;
        private ApiService apiService;

        private readonly UserManager<IdentityUser> _userManager;

        public PortfolioController(
            ILogger<AlertController> logger,
            ApplicationDbContext context,
            IHttpClientFactory httpClientFactory,
            UserManager<IdentityUser> userManager
            )
        {
            _logger = logger;
            portfolioService = new PortfolioService(context);
            currencyService = new CurrencyService(context);
            apiService = new ApiService(httpClientFactory);
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            return View(await getUserPortfolio());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var currList = await currencyService.GetCurrencies();
            ViewBag.currencies = currList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PortfolioEntry portfolio)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(User);
            portfolio.UserId = id;
            await portfolioService.PostPortfolio(portfolio);
            return View("Index", await getUserPortfolio());
        }

        private async Task<IEnumerable<PortfolioEntry>> getUserPortfolio()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(User);
            return await portfolioService.GetUserPortfolio(id);
        }
    }
}
