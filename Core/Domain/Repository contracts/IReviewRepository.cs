using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviewsForProduct(Guid productId);
        Task<Review?> GetReviewById(Guid reviewId);
        Task<Review> CreateReview(Review review);
        Task<Review> UpdateReview(Review review);
        Task<bool> DeleteReviewById(Guid reviewId);
    }
}
