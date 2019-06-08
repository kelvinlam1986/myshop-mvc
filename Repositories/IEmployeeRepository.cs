using System.Collections.Generic;
using shop.Models;

namespace shop.Repositories
{
    public interface IEmployeeRepository
    {
         IList<Employee> GetEmployees();
    }
}