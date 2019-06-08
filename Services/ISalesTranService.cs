


namespace shop.Services
{
    public interface ISalesTranService
    {
        void AddTransaction(int customerId, int productId, int quantity, out string errorMessage);
        void UpdateLine(int transTempId, int quantity, out string errorMessage);
        void DeleteLine(int transTempId, out string errorMessage);
        void AddSalesOrder(int customerId, string userId, decimal total,
             decimal discount, decimal payment, decimal amountdue,
             decimal tendered, decimal change, out string errorMessage);
        void CancelOrder(int customerId, out string errorMessage);
    }
}