using shop.Data;
using shop.Models;

namespace shop.Repositories
{
    public class SalesDetailRepository : ISalesDetailRepository
    {
        private ShopContext _context;

        public SalesDetailRepository(ShopContext context)
        {
            this._context = context;
        }

        public void AddSalesDetailTransaction(SalesDetail salesDetail)
        {
            this._context.SalesDetails.Add(salesDetail);
        }
    }
}