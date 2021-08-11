
namespace E_Store.Data.Interfaces.Repositories
{
    using System.Linq;
    
    using Data;
    using Models;
    
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly EStoreDbContext context;

        public ProductRepository(EStoreDbContext context) : base(context)
        {
        }

        public Product FindByUrl(string url)
        {
            return dbSet
                .Where(p => p.Url == url && !p.Hidden)
                .Select(p => p)
                .FirstOrDefault();
        }
    }
}