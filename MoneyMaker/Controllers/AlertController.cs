using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyMaker.Data;
using MoneyMaker.Services;

namespace MoneyMaker.Controllers;

public class AlertController : Controller
{
    private readonly ILogger<AlertController> _logger;
    private AlertService alertService;
    public AlertController(
        ILogger<AlertController> logger,
        ApplicationDbContext context
        )
    {
        _logger = logger;
        alertService = new AlertService(context);
    }

    public async Task<IActionResult> Index()
    {
        var userAlerts = await alertService.GetAlerts();
        return View(userAlerts);
    }

}


