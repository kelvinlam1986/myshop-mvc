using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Repositories;

namespace shop.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository employeeRepository) {
            this._repository = employeeRepository;
        }

        public IActionResult Index() {
            IList<Employee> employess = this._repository.GetEmployees();
            return View(employess);
        }
    }
}