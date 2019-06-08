using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace shop.ViewModels.Product
{
    public class NewProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Tên sản phẩm !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Mã sản phẩm !")]
        public string Serial { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Giá sản phẩm !")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Danh mục !")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Nhà cung cấp !")]
        public int SupplierId { get; set; }
        public string Reorder { get; set; }
        public IFormFile PictureFile { get; set; }
    }
}