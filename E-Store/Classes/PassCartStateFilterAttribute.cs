namespace E_Store.Classes
{
    using System;
    using Business.Interfaces;
    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    
    public class PassCartStateFilterAttribute : ResultFilterAttribute
    {
        private readonly IOrderManager orders;

        PassCartStateFilterAttribute(IOrderManager orders)
            => this.orders = orders;
        
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var provider = context.HttpContext.RequestServices;
            var orderManager = GetService<IOrderManager>(provider);
            ((Controller) context.Controller).ViewData["CartItemsSum"] =
                this.orders.GetOrderSummary().Price;
        }


        private T GetService<T>(IServiceProvider services)
            => (T) services.GetService(typeof(T));
    }
}