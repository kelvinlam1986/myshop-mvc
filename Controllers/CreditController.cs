using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;

namespace shop.Controllers
{
    public class CreditController : Controller
    {
        public IActionResult Index()
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}