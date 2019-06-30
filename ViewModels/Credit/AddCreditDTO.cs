namespace shop.ViewModels.Credit
{
    public class AddCreditDTO
    {
        public int CustomerId { get; set; }
        public string Interest { get; set; }
        public string GrandTotal { get; set; }
        public string DownPayment { get; set; }
        public string TermName { get; set; }
        public string PayableFor { get; set; }
    }
}