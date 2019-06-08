namespace shop.ViewModels.SalesTransaction
{
    public class SalesTranLineDTO
    {
        public int TransTempId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total
        {
            get { return Quantity * Price; }
        }
    }
}