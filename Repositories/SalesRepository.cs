using System;
using System.Collections.Generic;
using System.Linq;
using shop.Data;
using shop.Models;
using shop.ViewModels.SalesTransaction;

namespace shop.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private ShopContext _context;

        public SalesRepository(ShopContext context)
        {
            this._context = context;
        }

        public void AddSalesTransaction(Sales sales)
        {
            this._context.Sales.Add(sales);
        }

        public SalesOrderPrintDTO GetSalesOrderPrint(int salesId)
        {
            var query = from s in this._context.Sales
                        join c in this._context.Customers on s.CustomerId equals c.Id
                        where s.Id == salesId
                        orderby s.Id descending
                        select new SalesOrderPrintDTO
                        {
                            SalesId = s.Id,
                            CustomerLastName = c.LastName,
                            CustomerFirstName = c.FirstName,
                            CustomerAddress = c.Address,
                            CustomerContact = c.Contact,
                            AmountDue = s.AmountDue,
                            Discount = s.Discount,
                            GrandTotal = s.Total,
                            Tendered = s.CashTendered,
                            Change = s.CashChange
                        };
            return query.FirstOrDefault();
        }

        public SalesOrderPrintDTO GeTheLastSalesOrderOf(int customerId)
        {
            var query = from s in this._context.Sales
                        join c in this._context.Customers on s.CustomerId equals c.Id
                        where s.CustomerId == customerId
                        orderby s.Id descending
                        select new SalesOrderPrintDTO
                        {
                            SalesId = s.Id,
                            CustomerLastName = c.LastName,
                            CustomerFirstName = c.FirstName,
                            CustomerAddress = c.Address,
                            CustomerContact = c.Contact,
                            AmountDue = s.AmountDue,
                            Discount = s.Discount,
                            GrandTotal = s.Total,
                            Tendered = s.CashTendered,
                            Change = s.CashChange
                        };
            return query.FirstOrDefault();

        }

        public IEnumerable<SalesDetailDTO> GetListSalesDetailOf(int salesId)
        {
            var query = from s in this._context.SalesDetails
                        join p in this._context.Products on s.ProductId equals p.Id
                        where s.SalesId == salesId
                        select new SalesDetailDTO
                        {
                            SalesId = s.SalesId,
                            ProductId = s.ProductId,
                            ProductName = p.Name,
                            Quantity = s.Quantity,
                            Price = s.Price
                        };

            return query.ToList();
        }
    }
}