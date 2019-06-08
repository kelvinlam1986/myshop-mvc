using System.Collections.Generic;
using shop.Models;
using shop.ViewModels.SalesTransaction;

namespace shop.Repositories
{
    public interface ITempTransRepository
    {
        int CountTempTransByProductId(int productId, int customerId);
        bool UpdateIncreaseQuantiyAndPrice(int productId, int customerId, int quantity, decimal price);
        bool AddTempTran(TempTrans tempTrans);
        IEnumerable<SalesTranLineDTO> GetAddedSalesLines(int customerId);
        bool UpdateQuantity(int transTempId, int quantity);
        bool DeleteLine(int transTempId);
        void DeleteAllTransByCustomerTransaction(int customerId);
    }
}