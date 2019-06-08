using System.Linq;
using shop.Data;
using shop.Models;

namespace shop.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private ShopContext _context;

        public BranchRepository(ShopContext context)
        {
            this._context = context;
        }

        public Branch GetOne()
        {
            return this._context.Branches.FirstOrDefault();
        }
    }
}