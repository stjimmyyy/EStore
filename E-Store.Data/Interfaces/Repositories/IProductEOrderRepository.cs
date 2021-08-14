namespace E_Store.Data.Interfaces.Repositories
{
    using System.Collections.Generic;

    using Models;
    
    public interface IProductEOrderRepository : IRepository<ProductEOrder>
    {
        ProductEOrder FindByOrderIdProductId(int orderId, int productId);
        
        IEnumerable<ProductEOrder> FindByOrderId(int orderId);
    }
}