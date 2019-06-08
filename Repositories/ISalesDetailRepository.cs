using shop.Models;

namespace shop.Repositories
{
    public interface ISalesDetailRepository
    {
        void AddSalesDetailTransaction(SalesDetail salesDetail);
    }
}