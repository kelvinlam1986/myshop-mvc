using System;
using shop.Data;

namespace shop.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopContext _context;

        public UnitOfWork(ShopContext context)
        {
            this._context = context;
        }

        public bool SaveChanges()
        {
            try
            {
                return this._context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}