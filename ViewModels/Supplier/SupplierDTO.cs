using System.ComponentModel.DataAnnotations;

namespace shop.ViewModels.Supplier
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tên nhà cung cấp !")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}