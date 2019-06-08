using System;
using System.Collections.Generic;
using System.Linq;
using shop.Data;
using shop.Models;

namespace shop.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ShopContext _context;

        public CustomerRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return this._context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return this._context.Customers.Find(id);
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                this._context.Add(customer);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                this._context.Update(customer);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                this._context.Remove(customer);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsExistingByFirstLastName(string firstName, string lastName, int id)
        {
            return this._context.Customers.Any(x => x.FirstName == firstName &&
                x.LastName == lastName && x.Id != id);
        }

        public IEnumerable<Customer> GetCreditors()
        {
            return this._context.Customers.Where(x => x.CreditStatus != null && x.CreditStatus != "").ToList();
        }

        public Customer GetCustomerByFirstAndLastName(string firstName, string lastName)
        {
            return this._context.Customers.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}