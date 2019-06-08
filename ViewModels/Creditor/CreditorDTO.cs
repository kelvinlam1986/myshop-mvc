using System;
using System.ComponentModel.DataAnnotations;

namespace shop.ViewModels.Creditor
{
    public class CreditorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tên công ty tín dụng !")]
        public string CiName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Ngày cấp !")]
        public string CiDate { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập ghi chú !")]
        public string CiRemarks { get; set; }
        public string CreditStatus { get; set; }
        public bool PaySlip { get; set; }
        public bool ValidId { get; set; }
        public bool Cert { get; set; }
        public bool Cedula { get; set; }
        public bool Income { get; set; }
    }
}