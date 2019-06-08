using System;
using System.Collections.Generic;
using System.Linq;
using shop.Data;
using shop.Models;
using shop.ViewModels.SalesTransaction;

namespace shop.Repositories
{
    public class TempTransRepository : ITempTransRepository
    {
        private ShopContext _context;

        public TempTransRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool AddTempTran(TempTrans tempTrans)
        {
            try
            {
                this._context.TempTrans.Add(tempTrans);
                int rowEffects = this._context.SaveChanges();
                return rowEffects == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CountTempTransByProductId(int productId, int customerId)
        {
            return this._context.TempTrans.Count(x => x.ProductId == productId
                && x.CustomerId == customerId);
        }

        public bool UpdateIncreaseQuantiyAndPrice(int productId, int customerId, int quantity, decimal price)
        {
            try
            {
                var tempTran = this._context.TempTrans
                    .FirstOrDefault(x => x.ProductId == productId && x.CustomerId == customerId);
                if (tempTran == null)
                {
                    return false;
                }

                tempTran.Quantity += quantity;
                tempTran.Price += price;

                this._context.TempTrans.Update(tempTran);
                int rowEffects = this._context.SaveChanges();
                return rowEffects == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<SalesTranLineDTO> GetAddedSalesLines(int customerId)
        {
            var query = from t in this._context.TempTrans
                        join p in this._context.Products on t.ProductId equals p.Id
                        where t.CustomerId == customerId
                        select new SalesTranLineDTO
                        {
                            TransTempId = t.Id,
                            ProductId = p.Id,
                            ProductName = p.Name,
                            Quantity = t.Quantity,
                            Price = p.Price,
                        };
            return query.ToList();
        }

        public bool UpdateQuantity(int transTempId, int quantity)
        {
            try
            {
                var transLine = this._context.TempTrans.FirstOrDefault(x => x.Id == transTempId);
                if (transLine == null)
                {
                    return false;
                }

                transLine.Quantity = quantity;
                this._context.TempTrans.Update(transLine);
                return this._context.SaveChanges() == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLine(int transTempId)
        {
            try
            {
                var line = this._context.TempTrans.Find(transTempId);
                if (line == null)
                {
                    return false;
                }

                this._context.TempTrans.Remove(line);
                return this._context.SaveChanges() == 1;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DeleteAllTransByCustomerTransaction(int customerId)
        {
            IEnumerable<TempTrans> tempTrans =
                this._context.TempTrans.Where(x => x.CustomerId == customerId).ToList();
            this._context.TempTrans.RemoveRange(tempTrans);
        }
    }
}