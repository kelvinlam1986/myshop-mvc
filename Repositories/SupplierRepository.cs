using System;
using System.Collections.Generic;
using System.Linq;
using shop.Data;
using shop.Models;

namespace shop.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private ShopContext _shopContext;

        public SupplierRepository(ShopContext context)
        {
            this._shopContext = context;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return this._shopContext.Suppliers.ToList();
        }

        public bool IsExistingSupplier(string name, int id)
        {
            return this._shopContext.Suppliers.Any(x => x.Name == name && x.Id != id);
        }

        public bool AddSupplier(Supplier supplier)
        {
            try
            {
                this._shopContext.Suppliers.Add(supplier);
                int rowsEffected = this._shopContext.SaveChanges();
                return rowsEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Supplier GetById(int id)
        {
            return this._shopContext.Suppliers.Find(id);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            try
            {
                this._shopContext.Suppliers.Update(supplier);
                int rowsEffected = this._shopContext.SaveChanges();
                return rowsEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}