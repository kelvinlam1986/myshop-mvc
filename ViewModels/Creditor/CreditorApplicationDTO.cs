using System;
using System.ComponentModel.DataAnnotations;

namespace shop.ViewModels.Creditor
{
    public class CreditorApplicationDTO
    {
        [Required(ErrorMessage = "Bạn phải nhập tên !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập họ !")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập ngày sinh !")]
        public string BirthDate { get; set; }
        public string NickName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Địa chỉ !")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số liên hệ !")]
        public string Contact { get; set; }
        public string HouseStatus { get; set; }
        public string Years { get; set; }
        public string Rent { get; set; }
        public string EmployerName { get; set; }
        public string EmployerNo { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerYear { get; set; }
        public string Occupation { get; set; }
        public string Salary { get; set; }
        public string Spouse { get; set; }
        public string SpouseEmp { get; set; }
        public string SpouseNo { get; set; }
        public string SpouseDetails { get; set; }
        public string SpouseIncome { get; set; }
        public string CoMaker { get; set; }
        public string CoMakerDetails { get; set; }
        public string CreditStatus { get; set; }
    }
}