namespace E_Store.Data.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Models;

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly EStoreDbContext context;

        public CategoryRepository(EStoreDbContext context) : base(context)
        {
            
        }

        public Category GetPaymentCategory() => this.dbSet.SingleOrDefault(x => x.Url == "delivery-methods");
        
        public List<Category> GetLeaves(bool includeHidden = false)
        {
            return this.dbSet
                .Where(x => x.ChildCategories.Count == 0 && !x.Hidden)
                .ToList();
        }

        public List<Category> GetRoots()
        {
            return dbSet.Where(x => x.ParentCategoryId == null && !x.Hidden)
                .OrderBy(x => x.OrderNo)
                .ToList();
        }
    }
}