using System.ComponentModel.DataAnnotations;

namespace shop.ViewModels.Customer
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Picture { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên !")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập họ !")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Địa chỉ !")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Số liên hệ !")]
        public string Contact { get; set; }
        public decimal Balance { get; set; }
        public string CreditStatus { get; set; }
        public bool IsActivate
        {
            get
            {
                return Balance > 0;
            }
        }
    }
}