using System;

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
        public string TermName { get; set; }
        public string PayableFor { get; set; }
        public DateTime DueDate { get; set; }
        public string CoMaker { get; set; }
        public decimal Interest { get; set; }
        public decimal Down { get; set; }
    }
}