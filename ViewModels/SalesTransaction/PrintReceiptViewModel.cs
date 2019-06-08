using System.Collections.Generic;
using shop.Models;

namespace shop.ViewModels.SalesTransaction
{
    public class PrintReceiptViewModel
    {
        public Branch Branch { get; set; }
        public SalesOrderPrintDTO SalesOrder { get; set; }
        public Payment Payment { get; set; }
        public IEnumerable<SalesDetailDTO> SalesDetails { get; set; }
    }
}