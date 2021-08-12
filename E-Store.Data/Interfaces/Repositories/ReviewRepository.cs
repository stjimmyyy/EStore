using System.Linq;

namespace E_Store.Data.Interfaces.Repositories
{
    using System.Collections.Generic;
    
    using Data;
    using Models;

    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(EStoreDbContext context) : base(context)
        {
        }

        public IEnumerable<Review> FindByProductId(int productId)
            => this.dbSet
                .Where(x => x.ProductId == productId)
                .ToList();

        public Review FindByUserIdProduct(string userId, int productId)
            => this.dbSet
                .SingleOrDefault(x => x.UserId == userId &&
                                      x.ProductId == productId);
    }
}