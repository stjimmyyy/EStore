namespace E_Store.Models.Order
{
    using System.Collections.Generic;
    using E_Store.Business.Classes;
    
    public class OrderIndexViewModel
    {
        public IEnumerable<OrderItemInfo> OrderItems { get; set; }
        
        public OrderSummary OrderSummary { get; set; }
    }
}