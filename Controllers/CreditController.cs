using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Repositories;
using shop.ViewModels.Credit;

namespace shop.Controllers
{
    public class CreditController : Controller
    {
        private ISalesRepository _salesRepository;

        public CreditController(ISalesRepository salesRepository)
        {
            this._salesRepository = salesRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index(int customerId)
        {
            // string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            // if (string.IsNullOrEmpty(username))
            // {
            //     return RedirectToAction("Login", "Account");
            // }
            int salesId = Convert.ToInt32(this.HttpContext.Session.GetInt32(SessionConstant.SalesId));
            var salesDetailList = this._salesRepository.GetListSalesDetailOf(salesId);
            ViewData["SalesDetails"] = salesDetailList;
            var addCreditDto = new AddCreditDTO { CustomerId = customerId };
            return View(addCreditDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddTerm(AddCreditDTO term)
        {
            return View();
        }
    }
}