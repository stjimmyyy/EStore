namespace E_Store.Business.Interfaces
{
    using Classes;
    using Data.Models;
    public interface IOrderManager
    {
        EOrder CreateOrder();
        EOrder GetOrder(int? orderId = null, bool create = true);
        bool IsProductAvailable(int productId);
        void AddProducts(int productId, int quantity, int? orderId = null, bool ignoreHiddenProducts = false);

        OrderSummary GetOrderSummary(int? orderId = null);
    }
}