namespace shop.ViewModels.SalesTransaction
{
    public class SalesDetailDTO
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}