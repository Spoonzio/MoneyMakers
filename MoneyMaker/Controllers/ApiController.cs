using AutoMapper;
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

    private readonly SignInManager<IdentityUser> _signInManager;

    private string LOCAL_CURRENCY = "CAD";

    public ApiController(
        ILogger<HomeController> logger,
        ApplicationDbContext context,
        IHttpClientFactory httpClientFactory,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager
        )
    {
        _logger = logger;
        apiService = new ApiService(httpClientFactory);
        currencyService = new CurrencyService(context);
        alertService = new AlertService(context);
        portfolioService = new PortfolioService(context);
        _userManager = userManager;
        _signInManager = signInManager;
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
    public async Task<ApiResponse> getUserAlert()
    {
        string userid = _userManager.GetUserId(User);
        ApiResponse response = new ApiResponse();

        if(User != null && userid != null && userid.Length>0){
            response.Code = "200";
            response.Data.Add("alert", await alertService.GetUserAlerts(userid));
            return response;
        }else{
            response.Code = "400";
            response.Data.Add("message", "not logged in");
            return response;
        }
    }



    //=====================================
    // Portfolio
    //=====================================
    // GET api/portfolio
    [HttpGet("portfolio")]
    [AllowAnonymous]
    public async Task<ApiResponse> getUserPortfolio()
    {
        string userid = _userManager.GetUserId(User);
        ApiResponse response = new ApiResponse();
        if(userid.Length>0){
            response.Code = "200";
            response.Data.Add("portfolio", await portfolioService.GetUserPortfolio(userid));
            return response;
        }else{
            response.Code = "400";
            response.Data.Add("message", "not logged in");
            return response;
        }
    }

    [HttpGet("portfolio/sum")]
    public async Task<ApiResponse> getUserPortfolioSum()
    {
        string userid = _userManager.GetUserId(User);
        ApiResponse response = new ApiResponse();
        if(userid.Length>0){
            response.Code = "200";

            float sum = 0;
            var portfolios = await portfolioService.GetUserPortfolio(userid);
            List<PortfolioEntry> portfolioEntries = portfolios.ToList();

            foreach (var portfolioEntry in portfolioEntries)
            {
                var rate = await apiService.GetRate(portfolioEntry.EntryCurrencySym, LOCAL_CURRENCY);
                float subTotal = rate * portfolioEntry.EntryValue;

                sum += subTotal;
            }

            response.Data.Add("sum", sum.ToString());            
            return response;
        }else{
            response.Code = "400";
            response.Data.Add("message", "not logged in");
            return response;
        }
    }

    //=====================================
    // Login & Register
    //=====================================
    // POST api/login
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ApiResponse> postLogin(SignInCredential cred)
    {

        ApiResponse response = new ApiResponse();
        
        var user = _userManager.Users.SingleOrDefault(u => u.UserName == cred.Email);
        if (user is null)
        {
            response.Code = "404";
            response.Data.Add("message", "User not found");
            return response;
        }

        var result = await _signInManager.PasswordSignInAsync(cred.Email, cred.Password, false, lockoutOnFailure: true);
        
        if (result.Succeeded)
        {
            response.Code = "200";
            response.Data.Add("message", "Logged in");
            return response;
        }
        if (result.RequiresTwoFactor)
        {
            response.Code = "400";
            response.Data.Add("message", "Require 2-factor");
            return response;
        }
        response.Code = "400";
        response.Data.Add("message", "Failed login");
        return response;
    }

    // get api/isLogin
    [HttpGet("isLogin")]
    [AllowAnonymous]
    public async Task<ApiResponse> getIsLogin()
    {
        ApiResponse response = new ApiResponse();
        string userid = _userManager.GetUserId(User);

        response.Code = "200";

        if(userid==null){
            response.Data.Add("login", false);
        }else{
            response.Data.Add("login", true);
        }

        return response;
    }

    // POST api/logout
    [HttpPost("logout")]
    [AllowAnonymous]
    public async Task<ApiResponse> postLogout()
    {
        await _signInManager.SignOutAsync();
        ApiResponse response = new ApiResponse();
        response.Code = "200";
        response.Data.Add("message", "Logged out");
        return response;
    }

    // GET api/register
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ApiResponse> getRegisterAsync(RegisterCredential cred)
    {
        var user = new IdentityUser(cred.Email);
        user.Email = cred.Email;

        var userCreateResult = await _userManager.CreateAsync(user, cred.Password);

        ApiResponse response = new ApiResponse();

        if (userCreateResult.Succeeded)
        {
            response.Code = "200";
            response.Data.Add("message", "Registration completed");
            return response;
        }else{
            response.Code = "400";
            response.Data.Add("message", userCreateResult.Errors.First().Description);
            return response;
        }
    }

}
