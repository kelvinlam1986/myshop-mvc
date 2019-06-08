
using System.Collections.Generic;

namespace shop.ViewModels.SalesTransaction
{
    public class SalesTransactionVievModel
    {
        public SalesTransactionVievModel()
        {
            AddSalesTranLineDTO = new AddSalesTranLineDTO();
            UpdatedSalesQuantityDTO = new UpdatedSalesQuantityDTO();
            DeleteSalesLineDTO = new DeleteSalesLineDTO();
            SalesOrderDTO = new SalesOrderDTO();
        }

        public AddSalesTranLineDTO AddSalesTranLineDTO { get; set; }
        public UpdatedSalesQuantityDTO UpdatedSalesQuantityDTO { get; set; }
        public DeleteSalesLineDTO DeleteSalesLineDTO { get; set; }
        public SalesOrderDTO SalesOrderDTO { get; set; }
    }
}