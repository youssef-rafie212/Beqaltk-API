using Core.Domain.Entities;
using Core.DTO.ReviewsDtos;

namespace Core.Services_contracts
{
    public interface IReviewServices
    {
        Task<List<Review>> GetAllReviewsForProduct(Guid productId);
        Task<Review> GetReviewById(Guid reviewId);
        Task<Review> CreateReview(CreateReviewDto review);
        Task<Review> UpdateReview(UpdateReviewDto review);
        Task<bool> DeleteReviewById(Guid reviewId);
    }
}
