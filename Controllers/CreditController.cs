using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Repositories;
using shop.Services;
using shop.ViewModels.Credit;

namespace shop.Controllers
{
    public class CreditController : Controller
    {
        private ISalesRepository _salesRepository;
        private IPaymentService _paymentService;

        public CreditController(
            ISalesRepository salesRepository,
            IPaymentService paymentService)
        {
            this._salesRepository = salesRepository;
            this._paymentService = paymentService;
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
            int salesId = Convert.ToInt32(this.HttpContext.Session.GetInt32(SessionConstant.SalesId));
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            decimal grandTotal = Convert.ToDecimal(term.GrandTotal);
            decimal down = Convert.ToDecimal(term.DownPayment);
            int payableFor = Convert.ToInt32(term.PayableFor);
            decimal interest = Convert.ToDecimal(term.Interest);
            string errorMessage = "";
            this._paymentService.PerformPayment(
                term.CustomerId,
                userId,
                salesId,
                term.TermName,
                grandTotal,
                down,
                payableFor,
                interest,
                out errorMessage);
            this.HttpContext.Session.Remove(SessionConstant.SalesId);
            return RedirectToAction("Index", "Home");
        }
    }
}