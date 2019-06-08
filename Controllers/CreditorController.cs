using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Repositories;
using shop.ViewModels.Creditor;

namespace shop.Controllers
{
    public class CreditorController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public CreditorController(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Application()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var creditors = this._customerRepository.GetCreditors();
            var creditorsDTO = this._mapper.Map<IEnumerable<Customer>, IEnumerable<CreditorDTO>>(creditors);
            return View(creditorsDTO);
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditCreditInsurance(int id)
        {
            var customer = this._customerRepository.GetCustomerById(id);
            var creditorDTO = this._mapper.Map<CreditorDTO>(customer);
            return View(creditorDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult UpdateCreditor(CreditorDTO creditor)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCreditInsurance", creditor);
            }

            var customerInDb = _customerRepository.GetCustomerById(creditor.Id);
            if (customerInDb == null)
            {
                TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                return RedirectToAction("Index");
            }

            customerInDb.CiName = creditor.CiName;
            customerInDb.CiDate = DateTime.ParseExact(creditor.CiDate, "dd/MM/yyyy", null);
            customerInDb.CiRemarks = creditor.CiRemarks;
            customerInDb.PaySlip = creditor.PaySlip;
            customerInDb.ValidId = creditor.ValidId;
            customerInDb.Cert = creditor.Cert;
            customerInDb.Cedula = creditor.Cedula;
            customerInDb.Income = creditor.Income;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddCreditor(CreditorApplicationDTO creditor)
        {
            if (!ModelState.IsValid)
            {
                return View("Application", creditor);
            }

            var customer = this._customerRepository
                .GetCustomerByFirstAndLastName(creditor.FirstName, creditor.LastName);

            if (customer != null)
            {
                customer.CreditStatus = "pending";
                customer.Contact = creditor.Contact;
                customer.FirstName = creditor.FirstName;
                customer.LastName = creditor.LastName;
                customer.Address = creditor.Address;
                customer.BirthDate = DateTime.ParseExact(creditor.BirthDate, "dd/MM/yyyy", null);
                customer.NickName = creditor.NickName;
                customer.HouseStatus = creditor.HouseStatus;
                customer.Years = creditor.Years;
                customer.Rent = creditor.Rent;
                customer.EmployerName = creditor.EmployerName;
                customer.EmployerNo = creditor.EmployerNo;
                customer.EmployerAddress = creditor.EmployerAddress;
                customer.EmployerYear = creditor.EmployerYear;
                customer.Occupation = creditor.Occupation;
                customer.Salary = creditor.Salary;
                customer.Spouse = creditor.Spouse;
                customer.SpouseEmp = creditor.SpouseEmp;
                customer.SpouseNo = creditor.SpouseNo;
                customer.SpouseDetails = creditor.SpouseDetails;
                customer.CoMaker = creditor.CoMaker;
                customer.CoMakerDetails = creditor.CoMakerDetails;
                customer.UpdatedBy = "admin";
                customer.UpdatedDate = DateTime.Now;

                bool isSuccess = this._customerRepository.UpdateCustomer(customer);
                if (isSuccess)
                {
                    if (isSuccess)
                    {
                        TempData["Success"] = "Cập nhật dữ liệu thành công !";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                        return View("Application", creditor);
                    }
                }
            }
            else
            {
                var creditorInDb = this._mapper.Map<Customer>(creditor);
                creditorInDb.Balance = 0;
                creditorInDb.CreditStatus = "pending";
                creditorInDb.Picture = "default.gif";
                creditorInDb.CreatedBy = "admin";
                creditorInDb.CreatedDate = DateTime.Now;
                creditorInDb.UpdatedBy = "admin";
                creditorInDb.UpdatedDate = DateTime.Now;
                bool isSuccess = this._customerRepository.AddCustomer(creditorInDb);
                if (isSuccess)
                {
                    TempData["Success"] = "Cập nhật dữ liệu thành công !";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                    return View("Application", creditor);
                }
            }

            return View("Application", creditor);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ViewApplication(int id)
        {
            var customer = this._customerRepository.GetCustomerById(id);
            var creditorDTO = this._mapper.Map<CreditorApplicationDTO>(customer);
            return View(creditorDTO);
        }
    }
}