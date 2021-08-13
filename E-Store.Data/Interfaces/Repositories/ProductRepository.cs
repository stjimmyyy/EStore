namespace E_Store.Data.Interfaces.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    
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
            return this.dbSet
                .Where(p => p.Url == url && !p.Hidden)
                .Select(p => p)
                .FirstOrDefault();
        }

        public List<Product> FindByCategoryId(int categoryId)
        {
            return this.dbSet
                .Where(x => x.CategoryProducts
                    .Select(c => c.CategoryId)
                .Contains(categoryId))
                .ToList();
        }

        public List<Product> SearchProducts(string searchPhrase)
        {
            return string.IsNullOrEmpty(searchPhrase)
                ? this.dbSet.Where(x => !x.Hidden).ToList()
                : this.dbSet.Where(x => !x.Hidden &&
                                        x.Title.Contains(searchPhrase) ||
                                        x.ShortDescription.Contains(searchPhrase) ||
                                        x.Description.Contains(searchPhrase)).ToList();
        }
    }
}