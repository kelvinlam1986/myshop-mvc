using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Models;
using shop.Repositories;
using shop.Services;
using shop.ViewModels.Customer;
using shop.ViewModels.SalesTransaction;

namespace shop.Controllers
{
    public class SalesTransactionController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IProductRepository _productRepository;
        private ISalesTranService _salesTranService;
        private ITempTransRepository _tempTransRepository;
        private IPaymentRepository _paymentRepository;
        private ISalesRepository _salesRepository;
        private IBranchRepository _branchRepository;
        private UserManager<ApplicationUser> _userManager;
        private IMapper _mapper;

        public SalesTransactionController(
                ICustomerRepository customerRepository,
                IProductRepository productRepository,
                ISalesTranService salesTranService,
                ITempTransRepository tempTransRepository,
                IPaymentRepository paymentRepository,
                ISalesRepository salesRepository,
                IBranchRepository branchRepository,
                UserManager<ApplicationUser> userManager,
                IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._productRepository = productRepository;
            this._salesTranService = salesTranService;
            this._tempTransRepository = tempTransRepository;
            this._salesRepository = salesRepository;
            this._paymentRepository = paymentRepository;
            this._branchRepository = branchRepository;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddNew()
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var addNewVM = new AddNewViewModel();
            var customers = this._customerRepository.GetCustomers().ToList();
            var customersVM = this._mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);
            addNewVM.ExistingCustomers = customersVM;
            return View(addNewVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddCustomer(CustomerDTO customer)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var addNewVM = new AddNewViewModel();
            var customers = this._customerRepository.GetCustomers().ToList();
            var customersVM = this._mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);
            addNewVM.ExistingCustomers = customersVM;

            if (!ModelState.IsValid)
            {
                addNewVM.Customer = customer;
                return View("AddNew", addNewVM);
            }

            bool isExisting = this._customerRepository.IsExistingByFirstLastName(
                customer.FirstName,
                customer.LastName,
                customer.Id
            );

            if (isExisting)
            {
                ModelState.AddModelError("", "Có khách hàng đã tồn tại với họ tên này. Xin chọn một tên khác.");
                addNewVM.Customer = customer;
                return View("AddNew", addNewVM);
            }

            var customerDb = this._mapper.Map<Customer>(customer);
            customerDb.Picture = "default.gif";
            customerDb.Balance = 0;
            customerDb.CreatedDate = DateTime.Now;
            customerDb.CreatedBy = "admin";
            customerDb.UpdatedDate = DateTime.Now;
            customerDb.UpdatedBy = "admin";
            bool success = this._customerRepository.AddCustomer(customerDb);
            if (success)
            {
                TempData["Success"] = "Cập nhật dữ liệu thành công !";
                return RedirectToAction("Index", "SalesTransaction", new { customerId = customerDb.Id });
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật dữ liệu thất bại !");
                addNewVM.Customer = customer;
                return View("AddNew", addNewVM);
            }

        }

        [HttpPost]
        public IActionResult ExistingCustomer(AddNewViewModel model)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var salesTransactionViewModel = new SalesTransactionVievModel();
            var customer = this._customerRepository.GetCustomerById(model.ExistingCustomerId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "SalesTransaction",
                    new { customerId = model.ExistingCustomerId });
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index(int customerId)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var salesTransactionViewModel = new SalesTransactionVievModel();
            var customer = this._customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var products = this._productRepository.GetProductsAvailable();
            var addedProducLine = this._tempTransRepository.GetAddedSalesLines(customerId);
            ViewData["AddedSalesLine"] = addedProducLine;
            ViewData["CustomerId"] = customerId;
            ViewData["Products"] = products;
            return View(salesTransactionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddLine(AddSalesTranLineDTO salesLine)
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
                return RedirectToAction("Index", "SalesTransaction",
                        new { customerId = salesLine.CustomerId });
            }

            return RedirectToAction("Index", "SalesTransaction",
                        new { customerId = salesLine.CustomerId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public IActionResult UpdateLine(UpdatedSalesQuantityDTO line)
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
                return RedirectToAction("Index", "SalesTransaction", new { customerId = line.CustomerId });
            }

            return RedirectToAction("Index", "SalesTransaction", new { customerId = line.CustomerId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteLine(DeleteSalesLineDTO line)
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
                return RedirectToAction("Index", "SalesTransaction", new { customerId = line.CustomerId });
            }

            return RedirectToAction("Index", "SalesTransaction", new { customerId = line.CustomerId });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public IActionResult AddSalesOrder(SalesOrderDTO salesOrder)
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
            this._salesTranService.AddSalesOrder(
                salesOrder.CustomerId,
                userId,
                total,
                discount,
                amountDue,
                amountDue,
                tendered,
                change,
                out errorMessage);
            if (errorMessage != "")
            {
                TempData["Fail"] = errorMessage;
                return RedirectToAction("Index", "SalesTransaction", new { customerId = salesOrder.CustomerId });
            }
            return RedirectToAction("PrintReceipt", "SalesTransaction", new { customerId = salesOrder.CustomerId });
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
                return RedirectToAction("Index", "SalesTransaction", new { customerId = id });
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult PrintReceipt(int customerId)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

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

            var branch = new Branch
            {
                Name = branchName,
                Address = branchAddress,
                Contact = branchContact
            };

            var salesOrderPrint = this._salesRepository.GeTheLastSalesOrderOf(customerId);
            var payment = this._paymentRepository.GetPaymentBySalesID(salesOrderPrint.SalesId);
            var salesDetails = this._salesRepository.GetListSalesDetailOf(salesOrderPrint.SalesId);

            var printOrder = new PrintReceiptViewModel();
            printOrder.Branch = branch;
            printOrder.SalesOrder = salesOrderPrint;
            printOrder.Payment = payment;
            printOrder.SalesDetails = salesDetails;

            return View(printOrder);
        }

    }
}