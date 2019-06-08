using System.Collections.Generic;
using shop.Models;

namespace shop.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers();
        bool IsExistingSupplier(string name, int id);
        bool AddSupplier(Supplier supplier);
        Supplier GetById(int id);
        bool UpdateSupplier(Supplier supplier);
    }
}