using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Repositories;
using shop.ViewModels.Customer;

namespace shop.Controllers
{
    public class AccountSummaryController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public AccountSummaryController(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public IActionResult Index(int customerId)
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var customer = this._customerRepository.GetCustomerById(customerId);
            var customerDTO = this._mapper.Map<CustomerDTO>(customer);
            return View(customerDTO);
        }
    }
}