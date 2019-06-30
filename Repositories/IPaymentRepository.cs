using shop.Models;

namespace shop.Repositories
{
    public interface IPaymentRepository
    {
        void AddPaymentTransaction(Payment payment);
        int GetOrNo();
        Payment GetPaymentBySalesID(int salesId);
        int GetOrNoCredit();
    }
}