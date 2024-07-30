using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.ReviewsDtos;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly ServicesHelpers _helpers;

        public ReviewServices(IReviewRepository reviewRepo, ServicesHelpers helpers)
        {
            _reviewRepo = reviewRepo;
            _helpers = helpers;
        }

        public async Task<Review> CreateReview(CreateReviewDto review)
        {
            await _helpers.ThrowIfProductDoesntExist(review.ProductId);
            await _helpers.ThrowIfUserDoesntExist(review.UserId);

            return await _reviewRepo.CreateReview(new Review()
            {
                Id = Guid.NewGuid(),
                ReviewRating = review.ReviewRating,
                ReviewText = review.ReviewText,
                UserId = review.UserId,
                ProductId = review.ProductId,
            });
        }

        public async Task<bool> DeleteReviewById(Guid reviewId)
        {
            return await _reviewRepo.DeleteReviewById(reviewId);
        }

        public async Task<List<Review>> GetAllReviewsForProduct(Guid productId)
        {
            await _helpers.ThrowIfProductDoesntExist(productId);
            return _reviewRepo.GetAllReviewsForProduct(productId);
        }

        public async Task<Review> GetReviewById(Guid reviewId)
        {
            await _helpers.ThrowIfReviewDoesntExist(reviewId);
            return (await _reviewRepo.GetReviewById(reviewId))!;
        }

        public async Task<Review> UpdateReview(UpdateReviewDto review)
        {
            await _helpers.ThrowIfReviewDoesntExist(review.Id);
            return await _reviewRepo.UpdateReview(new Review()
            {
                Id = review.Id,
                ReviewRating = review.ReviewRating,
                ReviewText = review.ReviewText,
            });
        }
    }
}
