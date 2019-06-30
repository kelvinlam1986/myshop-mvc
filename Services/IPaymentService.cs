namespace shop.Services
{
    public interface IPaymentService
    {
        void PerformPayment(int customerId,
            string userId,
            int salesId,
            string terms,
            decimal grandTotal,
            decimal down,
            int payableFor,
            decimal interest,
            out string errorMessage);
    }
}