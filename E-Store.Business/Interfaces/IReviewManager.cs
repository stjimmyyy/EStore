namespace E_Store.Business.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;
    
    public interface IReviewManager
    {
        IEnumerable<Review> GetReviews(int productId);

        void AddReview(Review review);
    }
}