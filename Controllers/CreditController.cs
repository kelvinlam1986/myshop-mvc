using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Repositories;
using shop.Services;
using shop.Models;
using shop.ViewModels.Credit;
using shop.ViewModels.SalesTransaction;

namespace shop.Controllers
{
    public class CreditController : Controller
    {
        private ISalesRepository _salesRepository;
        private IPaymentService _paymentService;
        private IBranchRepository _branchRepository;
        private IPaymentRepository _paymentRepository;

        public CreditController(
            ISalesRepository salesRepository,
            IBranchRepository branchRepository,
            IPaymentRepository paymentRepository,
            IPaymentService paymentService)
        {
            this._salesRepository = salesRepository;
            this._paymentService = paymentService;
            this._branchRepository = branchRepository;
            this._paymentRepository = paymentRepository;
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

        [HttpGet]
        [Authorize]
        public IActionResult PrintReceipt()
        {
            int salesId = Convert.ToInt32(this.HttpContext.Session.GetInt32(SessionConstant.SalesId));
            var branchName = this.HttpContext.Session.GetString(
                SessionConstant.BranchNameSession
            );
            var branchAddress = this.HttpContext.Session.GetString(
                SessionConstant.BranchAddressSession
            );
            var branchContact = this.HttpContext.Session.GetString(
                SessionConstant.BranchContactSession
            );

            if (string.IsNullOrEmpty(branchAddress) && string.IsNullOrEmpty(branchName)
                 && string.IsNullOrEmpty(branchContact))
            {
                var branchInDb = this._branchRepository.GetOne();
                branchName = branchInDb.Name;
                branchAddress = branchInDb.Address;
                branchContact = branchInDb.Contact;
            }

            var salesOrder = this._salesRepository.GetSalesOrderTermPrint(salesId);
            var payment = this._paymentRepository.GetPaymentBySalesID(salesOrder.SalesId);
            var salesDetails = this._salesRepository.GetListSalesDetailOf(salesOrder.SalesId);

            var branch = new Branch
            {
                Name = branchName,
                Address = branchAddress,
                Contact = branchContact
            };

            var printOrder = new PrintReceiptViewModel();
            printOrder.Branch = branch;
            printOrder.SalesOrder = salesOrder;
            printOrder.Payment = payment;
            printOrder.SalesDetails = salesDetails;

            return View(printOrder);
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
            return RedirectToAction("PrintReceipt", "Credit");
        }
    }
}