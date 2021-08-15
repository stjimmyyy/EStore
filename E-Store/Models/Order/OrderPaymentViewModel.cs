namespace E_Store.Models.Order
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class OrderPaymentViewModel
    {
        public SelectList PaymentMethods { get; set; }
    }
}