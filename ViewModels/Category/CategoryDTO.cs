using System.ComponentModel.DataAnnotations;

namespace shop.ViewModels.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên danh mục !")]
        public string Name { get; set; }
    }
}