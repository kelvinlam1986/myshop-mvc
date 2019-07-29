using System.Linq;
using shop.Data;
using shop.Models;

namespace shop.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private ShopContext _context;

        public PaymentRepository(ShopContext context)
        {
            this._context = context;
        }

        public void AddPaymentTransaction(Payment payment)
        {
            this._context.Payments.Add(payment);
        }

        public int GetOrNo()
        {
            var query = (from p in this._context.Payments
                         join s in this._context.Sales on p.SalesId equals s.Id
                         orderby p.Id descending
                         select p.OrNo).FirstOrDefault();
            return query;
        }

        public int GetOrNoCredit()
        {
            var query = (from p in this._context.Payments
                         join s in this._context.Sales on p.SalesId equals s.Id
                         where s.ModeOfPayment == "credit" && p.OrNo != 0
                         orderby p.Id descending
                         select p.OrNo).FirstOrDefault();
            return query;
        }

        public Payment GetPaymentBySalesID(int salesId)
        {
            var payment = this._context.Payments.OrderByDescending(x => x.Id).FirstOrDefault(x => x.SalesId == salesId);
            return payment;
        }

    }
}