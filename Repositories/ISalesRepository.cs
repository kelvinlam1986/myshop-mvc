using System.Collections.Generic;
using shop.Models;
using shop.ViewModels.SalesTransaction;

namespace shop.Repositories
{
    public interface ISalesRepository
    {
        void AddSalesTransaction(Sales sales);
        SalesOrderPrintDTO GetSalesOrderPrint(int salesId);
        SalesOrderPrintDTO GetSalesOrderTermPrint(int salesId);
        SalesOrderPrintDTO GeTheLastSalesOrderOf(int customerId);
        IEnumerable<SalesDetailDTO> GetListSalesDetailOf(int salesId);
    }
}