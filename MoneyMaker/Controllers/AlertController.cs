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
        apiService = new ApiService(httpClientFactory);
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userAlerts = await alertService.GetAlerts();
        return View(userAlerts);
    }

    public async Task<IActionResult> Create()
    {
        var alert = new Alert();
        alert.FromCurrency = "USD";
        alert.ToCurrency = "CAD";
        var currValue = await apiService.GetRate("USD", "CAD");
        alert.ConditionValue = currValue;
        alert.isBelow = false;
        alert.CreateDate = DateTime.Today;

        System.Security.Claims.ClaimsPrincipal currentUser = this.User;
        var id = _userManager.GetUserId(User); // Get user id:
        alert.UserId = id;

        return View(alert);
    }

    [HttpPost]
    public async Task<IActionResult> onPostCreate(CreateAlertViewModel model)
    {
        // TODO
        return View();
    }

}


