namespace E_Store.Business.Interfaces
{
    using System.Collections.Generic;
    
    using Microsoft.AspNetCore.Http;
    
    using Classes;
    using Data.Models;
    public interface IOrderManager
    {
        EOrder CreateOrder();
        EOrder GetOrder(int? orderId = null, bool create = true);
        bool IsProductAvailable(int productId);
        void AddProducts(int productId, int quantity, int? orderId = null, bool ignoreHiddenProducts = false);
        OrderSummary GetOrderSummary(int? orderId = null);
        List<OrderItemInfo> GetProducts(int? orderId = null);
        void UpdateCart(IFormCollection form);
        void SetPerson(Person person, int? orderId = null);
        Dictionary<int, string> GetPaymentMethods();
        void SetDeliveryProduct(int deliveryProductId);

        void CompleteOrder(string emailBody);
    }
}