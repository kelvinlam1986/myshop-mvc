namespace shop.ViewModels.SalesTransaction
{
    public class SalesOrderDTO
    {
        public int CustomerId { get; set; }
        public string Total { get; set; }
        public string Discount { get; set; }
        public string AmountDue { get; set; }
        public string Tendered { get; set; }
        public string Change { get; set; }
    }
}