namespace E_Store.Models.Order
{
    using System.Collections.Generic;
    using E_Store.Business.Classes;
    using E_Store.Data.Models;
    
    public class OrderSummaryViewModel
    {
        public IEnumerable<OrderItemInfo> OrderItems { get; set; }
        
        public Person Person { get; set; }
        
        public Address DeliveryAddress { get; set; }
        
        public OrderSummary Summary { get; set; }
        
        public bool Registered { get; set; }
        
        public int OrderId { get; set; }
    }
}