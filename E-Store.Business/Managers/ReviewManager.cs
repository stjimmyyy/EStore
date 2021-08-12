namespace E_Store.Business.Managers
{
    using System;
    using System.Collections.Generic;
 
    using E_Store.Data.Interfaces.Repositories;
    using Interfaces;
    using Data.Models;
    
    public class ReviewManager : IReviewManager
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewManager(IReviewRepository repository)
        {
            this.reviewRepository = repository;
        }

        public IEnumerable<Review> GetReviews(int productId)
            => this.reviewRepository.FindByProductId(productId);
        
        public void AddReview(Review review)
        {
            if (this.reviewRepository.FindByUserIdProduct(review.UserId, review.ProductId) == null)
            {
                review.Sent = DateTime.Now;
                this.reviewRepository.Insert(review);
            }
            else
            {
                throw new Exception("You have already reviewed this product.");
            }
        }
    }
}