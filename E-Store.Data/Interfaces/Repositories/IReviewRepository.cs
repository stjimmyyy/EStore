namespace E_Store.Data.Interfaces.Repositories
{
    using System.Collections.Generic;

    using Models;
    
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> FindByProductId(int productId);
        Review FindByUserIdProduct(string userId, int productId);
    }
}