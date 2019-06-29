
namespace shop.ViewModels.SalesTransactionCredit
{
    public class SalesTransactionCreditViewModel
    {
        public SalesTransactionCreditViewModel()
        {
            AddSalesTranCreditLineDTO = new AddSalesTranCreditLineDTO();
            UpdatedSalesCreditQuantityDTO = new UpdatedSalesCreditQuantityDTO();
            DeleteSalesCreditLineDTO = new DeleteSalesCreditLineDTO();
            SalesOrderCreditDTO = new SalesOrderCreditDTO();
        }

        public AddSalesTranCreditLineDTO AddSalesTranCreditLineDTO { get; set; }
        public UpdatedSalesCreditQuantityDTO UpdatedSalesCreditQuantityDTO { get; set; }
        public DeleteSalesCreditLineDTO DeleteSalesCreditLineDTO { get; set; }
        public SalesOrderCreditDTO SalesOrderCreditDTO { get; set; }
    }
}