using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Microsoft.AspNetCore.Identity;

namespace Core.Helpers
{
    public class ServicesHelpers
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IFavouritesListRepository _favouritesListRepo;
        private readonly IFavouritesListItemRepository _favouritesListItemRepo;
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly IReviewRepository _reviewRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServicesHelpers(ICategoryRepository categoryRepo,
                IProductRepository productRepo,
                UserManager<ApplicationUser> userManager,
                ICartRepository cartRepository,
                IOrderRepository orderRepository,
                IFavouritesListRepository favouritesListRepository,
                IFavouritesListItemRepository favouritesListItemRepository,
                ICartItemRepository cartItemRepository,
                IOrderItemRepository orderItemRepository,
                IReviewRepository reviewRepository
                )
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _cartRepo = cartRepository;
            _userManager = userManager;
            _orderRepo = orderRepository;
            _favouritesListRepo = favouritesListRepository;
            _favouritesListItemRepo = favouritesListItemRepository;
            _cartItemRepo = cartItemRepository;
            _orderItemRepo = orderItemRepository;
            _reviewRepo = reviewRepository;
        }

        public async Task ThrowIfCategoryDoesntExist(Guid categoryId)
        {
            Category? category = await _categoryRepo.GetCategoryById(categoryId);
            if (category == null) throw new Exception("Category doesn't exist");
        }

        public async Task ThrowIfProductDoesntExist(Guid productId)
        {
            Product? product = await _productRepo.GetProductById(productId);
            if (product == null) throw new Exception("Product doesn't exist");
        }

        public async Task ThrowIfUserDoesntExist(Guid userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) throw new Exception("User doesn't exist");
        }
        public async Task ThrowIfOrderDoesntExist(Guid orderId)
        {
            Order? order = await _orderRepo.GetOrderById(orderId);
            if (order == null) throw new Exception("Order doesn't exist");
        }

        public async Task ThrowIfCartDoesntExist(Guid cartId)
        {
            Cart? cart = await _cartRepo.GetCartById(cartId);
            if (cart == null) throw new Exception("Cart doesn't exist");
        }

        public async Task ThrowIfFavListDoesntExist(Guid favListId)
        {
            FavouritesList? favList = await _favouritesListRepo.GetFavouritesListById(favListId);
            if (favList == null) throw new Exception("Fav. list doesn't exist");
        }

        public async Task ThrowIfFavListItemDoesntExist(Guid favListItemId)
        {
            FavouritesListItem? favListItem = await _favouritesListItemRepo.GetFavouritesListItemById(favListItemId);
            if (favListItem == null) throw new Exception("Fav. list item doesn't exist");
        }

        public async Task ThrowIfCartItemDoesntExist(Guid cartItemId)
        {
            CartItem? cartItem = await _cartItemRepo.GetCartItemById(cartItemId);
            if (cartItem == null) throw new Exception("Cart item doesn't exist");
        }

        public async Task ThrowIfOrderItemDoesntExist(Guid orderItemId)
        {
            OrderItem? orderItem = await _orderItemRepo.GetOrderItemById(orderItemId);
            if (orderItem == null) throw new Exception("Order item doesn't exist");
        }

        public async Task ThrowIfReviewDoesntExist(Guid reviewId)
        {
            Review? review = await _reviewRepo.GetReviewById(reviewId);
            if (review == null) throw new Exception("Review doesn't exist");
        }

        public List<T> GetRandomElements<T>(List<T> list, int numberOfElements)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("The list cannot be null or empty.");
            }

            if (numberOfElements <= 0 || numberOfElements > list.Count)
            {
                throw new ArgumentException("The number of elements to retrieve must be greater than 0 and less than or equal to the list count.");
            }

            Random random = new Random();
            return list.OrderBy(x => random.Next()).Take(numberOfElements).ToList();
        }
    }
}
