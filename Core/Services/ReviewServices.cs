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
        private readonly IProductRepository _productRepo;
        private readonly ServicesHelpers _helpers;

        public ReviewServices(
            IReviewRepository reviewRepo,
            IProductRepository productRepo,
            ServicesHelpers helpers
            )
        {
            _reviewRepo = reviewRepo;
            _productRepo = productRepo;
            _helpers = helpers;
        }

        public async Task<Review> CreateReview(CreateReviewDto review)
        {
            await _helpers.ThrowIfProductDoesntExist(review.ProductId);
            await _helpers.ThrowIfUserDoesntExist(review.UserId);

            // Update realted product rating and rating number
            Product product = (await _productRepo.GetProductById(review.ProductId))!;

            int ratingsSum = 0;
            List<int> allRatings = _reviewRepo.GetAllReviewsForProduct(review.ProductId).Select(r => r.ReviewRating).ToList();
            foreach (int rating in allRatings)
            {
                ratingsSum += rating;
            }
            // Add the new review rating to the sum to get the new average rating
            ratingsSum += review.ReviewRating;

            int averageRating = ratingsSum / (product.NumberOfRatings + 1);

            await _productRepo.UpdateProduct(new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
                Weight = product.Weight,
                Rating = averageRating,
                NumberOfRatings = product.NumberOfRatings + 1,
            });

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
            // Update realted product rating and rating number
            Review? review = await _reviewRepo.GetReviewById(reviewId);
            if (review == null) return false;

            Product product = (await _productRepo.GetProductById(review.ProductId))!;

            int ratingsSum = 0;
            List<int> allRatings = _reviewRepo.GetAllReviewsForProduct(review.ProductId).Select(r => r.ReviewRating).ToList();
            foreach (int rating in allRatings)
            {
                ratingsSum += rating;
            }
            // Delete the review rating from the sum to get the new average rating
            ratingsSum -= review.ReviewRating;

            int averageRating = ratingsSum / (product.NumberOfRatings - 1);

            await _productRepo.UpdateProduct(new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
                Weight = product.Weight,
                Rating = averageRating,
                NumberOfRatings = product.NumberOfRatings - 1,
            });

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

            // Update realted product rating and rating number
            Review reviewForProduct = (await _reviewRepo.GetReviewById(review.Id))!;
            Product product = (await _productRepo.GetProductById(reviewForProduct.ProductId))!;

            int ratingsSum = 0;
            List<int> allRatings = _reviewRepo.GetAllReviewsForProduct(reviewForProduct.ProductId).Select(r => r.ReviewRating).ToList();
            foreach (int rating in allRatings)
            {
                ratingsSum += rating;
            }
            // Add / Delete the new review rating to / from the sum to get the new average rating
            if (review.ReviewRating > reviewForProduct.ReviewRating)
            {
                ratingsSum += (review.ReviewRating - reviewForProduct.ReviewRating);
            }
            else if (review.ReviewRating < reviewForProduct.ReviewRating)
            {
                ratingsSum -= (reviewForProduct.ReviewRating - review.ReviewRating);
            }

            int averageRating = ratingsSum / product.NumberOfRatings;

            await _productRepo.UpdateProduct(new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
                Weight = product.Weight,
                Rating = averageRating,
                NumberOfRatings = product.NumberOfRatings,
            });

            return await _reviewRepo.UpdateReview(new Review()
            {
                Id = review.Id,
                ReviewRating = review.ReviewRating,
                ReviewText = review.ReviewText,
            });
        }
    }
}
