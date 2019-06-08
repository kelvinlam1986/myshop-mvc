using Microsoft.AspNetCore.Mvc;

namespace shop.Controllers
{
    public class AccountSummaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}