using System.Collections.Generic;
using shop.Models;

namespace shop.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IList<Employee> GetEmployees()
        {
            return new List<Employee> {
                new Employee { EmployeeNo = 1, EmployeeName = "Minh" },
                new Employee { EmployeeNo = 2, EmployeeName = "Nga" }
            };
        }
    }
}