

using System.Collections.Generic;
using shop.Models;
using shop.ViewModels.Product;

namespace shop.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<ProductDTO> GetProductsView();
        IEnumerable<Product> GetProductsAvailable();
        bool IsExistingProductCodeOrName(string serial, string name, int id);
        bool AddProduct(Product product);
        Product GetById(int id);
        bool UpdateProduct(Product product);
        void UpdateQuantityAfterSalesTransaction(int id, int quantity);
    }
}