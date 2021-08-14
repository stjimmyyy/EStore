namespace E_Store.Data.Interfaces.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
        
    using Data;
    using Models;
    
    public class ProductEOrderRepository : BaseRepository<ProductEOrder>, IProductEOrderRepository
    {
        public ProductEOrderRepository(EStoreDbContext context) : base(context)
        {
        }

        public ProductEOrder FindByOrderIdProductId(int orderId, int productId)
            => this.dbSet
                .SingleOrDefault(x => x.EOrderId == orderId && x.ProductId == productId);

        public IEnumerable<ProductEOrder> FindByOrderId(int orderId)
            => this.dbSet.Where(x => x.EOrderId == orderId);
    }
}