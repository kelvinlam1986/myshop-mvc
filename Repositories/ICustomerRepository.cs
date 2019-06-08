using System.Collections.Generic;
using shop.Models;

namespace shop.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        IEnumerable<Customer> GetCreditors();
        bool IsExistingByFirstLastName(string firstName, string lastName, int id);
        Customer GetCustomerByFirstAndLastName(string firstName, string lastName);
    }
}