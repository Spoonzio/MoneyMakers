using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;
using MoneyMaker.Services;
using MoneyMaker.ViewModels;
using MoneyMaker.Models;
using Microsoft.AspNetCore.Identity;

namespace MoneyMaker.Controllers;

public class AlertController : Controller
{
    private readonly ILogger<AlertController> _logger;
    private AlertService alertService;
    private CurrencyService currencyService;
    private ApiService apiService;

    private readonly UserManager<IdentityUser> _userManager;

    public AlertController(
        ILogger<AlertController> logger,
        ApplicationDbContext context,
        IHttpClientFactory httpClientFactory,
        UserManager<IdentityUser> userManager
        )
    {
        _logger = logger;
        alertService = new AlertService(context);
        currencyService = new CurrencyService(context);
        apiService = new ApiService(httpClientFactory);
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        return View(await getUserAlert());
    }

    public async Task<IActionResult> Create()
    {
        var alert = new Alert();
        alert.FromCurrency = "USD";
        alert.ToCurrency = "CAD";
        var currValue = await apiService.GetRate("USD", "CAD");
        alert.ConditionValue = (float)Math.Round(currValue, 2);
        alert.isBelow = false;
        alert.CreateDate = DateTime.Today;

        System.Security.Claims.ClaimsPrincipal currentUser = this.User;
        var id = _userManager.GetUserId(User); // Get user id:
        alert.UserId = id;

        var currList = await currencyService.GetCurrencies();
        ViewBag.currencies = currList;

        return View(alert);
    }


    public async Task<IActionResult> onPostCreate(Alert model)
    {
        if(model != null)
        {
            bool ex = await alertService.AlertExists(model.UserId, model.FromCurrency, model.ToCurrency);

            if (ex)
            {
                ViewBag.errorMessage = "Alert for this conversion already exists, try editing";
                return View("Create", model);
            }
        }

        await alertService.PostAlert(model);


        return View("Index", await getUserAlert());
    }


    public async Task<IActionResult> Delete(string UserId, string FromCurrency, string ToCurrency)
    {
        System.Security.Claims.ClaimsPrincipal currentUser = this.User;
        var id = _userManager.GetUserId(User);

        if (UserId != null 
            && id == UserId
            && FromCurrency != null 
            && ToCurrency != null)
        {
            var successawait = await alertService.DeleteAlert(UserId, FromCurrency, ToCurrency);
        }

        return View("Index", await getUserAlert());

    }

    public async Task<IActionResult> Edit(string UserId, string FromCurrency, string ToCurrency)
    {
        var alert = await alertService.GetAlert(UserId, FromCurrency, ToCurrency);
        return View(alert);
    }

    public async Task<IActionResult> onPostEdit(Alert editAlert)
    {
        await alertService.PutAlert(editAlert);
        var userAlerts = await getUserAlert();
        return View("Index", userAlerts);
    }

    private async Task<IEnumerable<Alert>> getUserAlert()
    {
        System.Security.Claims.ClaimsPrincipal currentUser = this.User;
        var id = _userManager.GetUserId(User);
        return await alertService.GetUserAlerts(id);
    }
}


