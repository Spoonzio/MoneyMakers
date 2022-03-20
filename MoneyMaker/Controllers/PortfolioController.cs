using Microsoft.AspNetCore.Mvc;

namespace MoneyMaker.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
