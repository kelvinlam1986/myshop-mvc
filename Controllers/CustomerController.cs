using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Models;
using shop.Repositories;
using shop.ViewModels.Customer;

namespace shop.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public CustomerController(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var customers = this._customerRepository.GetCustomers();
            var customersDTO = this._mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return View(customersDTO);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var customer = this._customerRepository.GetCustomerById(id);
            var customerDTO = this._mapper.Map<CustomerDTO>(customer);
            return View(customerDTO);
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
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteCustomer(CustomerDTO customerDTO)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var customer = this._mapper.Map<Customer>(customerDTO);
            bool isSuccess = this._customerRepository.DeleteCustomer(customer);
            if (isSuccess)
            {
                TempData["Success"] = "Xoá dữ liệu thành công !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Fail"] = "Xoá dữ liệu thất bại !";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult UpdateCustomer(CustomerDTO customer)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", customer);
            }

            bool isExisting = this._customerRepository.IsExistingByFirstLastName(
                customer.FirstName,
                customer.LastName,
                customer.Id
            );

            if (isExisting)
            {
                ModelState.AddModelError("", "Có khách hàng đã tồn tại với họ tên này. Xin chọn một tên khác.");
                return View("Edit", customer);
            }

            var customerInDb = _customerRepository.GetCustomerById(customer.Id);
            if (customerInDb == null)
            {
                TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                return RedirectToAction("Index");
            }

            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.Address = customer.Address;
            customerInDb.Contact = customer.Contact;
            customerInDb.UpdatedBy = "admin";
            customerInDb.UpdatedDate = DateTime.Now;

            bool isSuccess = this._customerRepository.UpdateCustomer(customerInDb);
            if (isSuccess)
            {
                TempData["Success"] = "Cập nhật dữ liệu thành công !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                return RedirectToAction("Index");
            }
        }
    }
}