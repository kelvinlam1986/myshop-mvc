using System.ComponentModel.DataAnnotations;

namespace shop.ViewModels.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string SupplierName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int Reorder { get; set; }
        public string Serial { get; set; }
    }
}