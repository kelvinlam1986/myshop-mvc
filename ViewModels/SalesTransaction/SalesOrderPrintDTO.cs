namespace shop.ViewModels.SalesTransaction
{
    public class SalesOrderPrintDTO
    {
        public int SalesId { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContact { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Tendered { get; set; }
        public decimal Change { get; set; }

    }
}