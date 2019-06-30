using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Models;
using shop.Repositories;
using shop.Services;
using shop.ViewModels.SalesTransactionCredit;

namespace shop.Controllers
{
    public class SalesTransactionCreditController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IProductRepository _productRepository;
        private ITempTransRepository _tempTransRepository;

        private ISalesTranService _salesTranService;

        private IMapper _mapper;

        public SalesTransactionCreditController(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            ITempTransRepository tempTransRepository,
            ISalesTranService salesTranService,
            IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._productRepository = productRepository;
            this._tempTransRepository = tempTransRepository;
            this._salesTranService = salesTranService;
            this._mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index(int customerId)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var salesTransactionCreditViewModel = new SalesTransactionCreditViewModel();
            var customer = this._customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var products = this._productRepository.GetProductsAvailable();
            var addedProducLine = this._tempTransRepository.GetAddedSalesLines(customerId);

            ViewData["CustomerId"] = customerId;
            ViewData["Products"] = products;
            ViewData["AddedSalesLine"] = addedProducLine;
            return View(salesTransactionCreditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddLine(AddSalesTranCreditLineDTO salesLine)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            string errorMessage = "";
            this._salesTranService
                    .AddTransaction(
                        salesLine.CustomerId,
                        salesLine.ProductId,
                        salesLine.Quantity,
                        out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["Fail"] = errorMessage;
                return RedirectToAction("Index", "SalesTransactionCredit",
                        new { customerId = salesLine.CustomerId });
            }

            return RedirectToAction("Index", "SalesTransactionCredit",
                        new { customerId = salesLine.CustomerId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public IActionResult UpdateLine(UpdatedSalesCreditQuantityDTO line)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            string errorMessage = "";
            this._salesTranService.UpdateLine(line.TransTempId, line.Quantity, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["Fail"] = errorMessage;
                return RedirectToAction("Index", "SalesTransactionCredit", new { customerId = line.CustomerId });
            }

            return RedirectToAction("Index", "SalesTransactionCredit", new { customerId = line.CustomerId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteLine(DeleteSalesCreditLineDTO line)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            string errorMessage = "";
            this._salesTranService.DeleteLine(line.TransTempId, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["Fail"] = errorMessage;
                return RedirectToAction("Index", "SalesTransactionCredit", new { customerId = line.CustomerId });
            }

            return RedirectToAction("Index", "SalesTransactionCredit", new { customerId = line.CustomerId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public IActionResult AddSalesOrder(SalesOrderCreditDTO salesOrder)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var discount = Convert.ToDecimal(salesOrder.Discount);
            var total = Convert.ToDecimal(salesOrder.Total);
            var amountDue = Convert.ToDecimal(salesOrder.AmountDue);
            var tendered = Convert.ToDecimal(salesOrder.Tendered);
            var change = Convert.ToDecimal(salesOrder.Change);
            string errorMessage = "";
            int salesId = 0;
            this._salesTranService.AddSalesOrderCredit(
                salesOrder.CustomerId,
                userId,
                total,
                out errorMessage,
                out salesId);
            if (errorMessage != "")
            {
                TempData["Fail"] = errorMessage;
                return RedirectToAction("Index", "SalesTransactionCredit", new { customerId = salesOrder.CustomerId });
            }

            this.HttpContext.Session.SetInt32(SessionConstant.SalesId, salesId);
            return RedirectToAction("Index", "Credit", new { customerId = salesOrder.CustomerId });
        }

        [HttpGet]
        [Authorize]
        public IActionResult CancelOrder(int id)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            string errorMessage = "";
            this._salesTranService.CancelOrder(id, out errorMessage);
            if (errorMessage != "")
            {
                TempData["Fail"] = errorMessage;
                return RedirectToAction("Index", "SalesTransactionCredit", new { customerId = id });
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult OldCustomer()
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var customers = this._customerRepository.GetCustomers();
            var searchCustomersDTO =
                this._mapper.Map<IEnumerable<Customer>, IEnumerable<SearchCustomerDTO>>(customers);
            ViewData["Customers"] = searchCustomersDTO;
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CustomerAccount(SearchCustomerDTO searchCustomer)
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