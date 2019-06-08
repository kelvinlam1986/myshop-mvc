using System.Collections.Generic;

namespace shop.ViewModels.Customer
{
    public class AddNewViewModel
    {
        public AddNewViewModel()
        {
            Customer = new CustomerDTO();
            ExistingCustomers = new List<CustomerDTO>();
        }

        public CustomerDTO Customer { get; set; }
        public IEnumerable<CustomerDTO> ExistingCustomers { get; set; }
        public int ExistingCustomerId { get; set; }
    }
}