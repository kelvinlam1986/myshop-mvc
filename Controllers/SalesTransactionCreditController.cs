using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Repositories;
using shop.ViewModels.SalesTransactionCredit;

namespace shop.Controllers
{
    public class SalesTransactionCreditController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public SalesTransactionCreditController(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult OldCustomer()
        {
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
            return View();
        }
    }
}