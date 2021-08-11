namespace E_Store.Data.Interfaces.Repositories
{
    using System.Linq;
    using Models;
    
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public Product FindByUrl(string url)
        {
            return dbSet
                .Where(p => p.Url == url && !p.Hidden)
                .Select(p => p)
                .FirstOrDefault();
        }
    }
}