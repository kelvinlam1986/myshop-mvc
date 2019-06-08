using System;
using System.Collections.Generic;
using System.Linq;
using shop.Data;
using shop.Models;
using shop.ViewModels.Product;

namespace shop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this._context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsAvailable()
        {
            return this._context.Products.Where(x => x.Quantity > 0).ToList();
        }
        public IEnumerable<ProductDTO> GetProductsView()
        {
            var query = from p in this._context.Products
                        join c in this._context.Categories on p.CategoryId equals c.Id
                        join s in this._context.Suppliers on p.SupplierId equals s.Id
                        select new ProductDTO
                        {
                            Id = p.Id,
                            ProductName = p.Name,
                            ProductDescription = p.Description,
                            Picture = p.Picture,
                            Price = p.Price,
                            Quantity = p.Quantity,
                            Reorder = p.Reorder,
                            CategoryName = c.Name,
                            SupplierName = s.Name,
                            Serial = p.Serial
                        };

            return query.ToList();
        }

        public bool IsExistingProductCodeOrName(string serial, string name, int id)
        {
            bool isExisting = this._context.Products.Any(x => x.Serial == serial && x.Id != id);
            if (isExisting)
            {
                return isExisting;
            }

            isExisting = this._context.Products.Any(x => x.Name == name && x.Id != id);
            return isExisting;
        }

        public bool AddProduct(Product product)
        {
            try
            {
                this._context.Products.Add(product);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Product GetById(int id)
        {
            return this._context.Products.Find(id);
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                this._context.Products.Update(product);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateQuantityAfterSalesTransaction(int id, int quantity)
        {
            var product = this._context.Products.Find(id);
            if (product != null)
            {
                product.Quantity = product.Quantity - quantity;
                this._context.Products.Update(product);
            }
        }
    }
}