using shop.Data;
using shop.Models;

namespace shop.Repositories
{
    public class TermRepository : ITermRepository
    {
        private ShopContext _context;

        public TermRepository(ShopContext context)
        {
            this._context = context;
        }

        public void AddTermTransaction(Term term)
        {
            this._context.Terms.Add(term);
        }
    }
}