using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDBContext _db;

        public ReviewRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Review> CreateReview(Review review)
        {
            _db.Reviews.Add(review);
            await _db.SaveChangesAsync();
            return review;
        }

        public async Task<bool> DeleteReviewById(Guid reviewId)
        {
            Review? review = await _db.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
            if (review == null) return false;
            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
            return true;
        }

        public List<Review> GetAllReviewsForProduct(Guid productId)
        {
            return _db.Reviews.Where(r => r.ProductId == productId).ToList();
        }

        public async Task<Review?> GetReviewById(Guid reviewId)
        {
            return await _db.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
        }

        public async Task<Review> UpdateReview(Review review)
        {
            Review? reviewToUpdate = await _db.Reviews.FirstOrDefaultAsync(r => r.Id == review.Id);

            reviewToUpdate.ReviewRating = review.ReviewRating;
            reviewToUpdate.ReviewText = review.ReviewText;

            await _db.SaveChangesAsync();
            return review;
        }
    }
}
