using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.ProductDtos;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepo;
        private readonly ServicesHelpers _helpers;

        public ProductServices(IProductRepository productRepo, ServicesHelpers helpers)
        {
            _productRepo = productRepo;
            _helpers = helpers;
        }

        public async Task<Product> CreateProduct(CreateproductDto product)
        {
            await _helpers.ThrowIfCategoryDoesntExist(product.CategoryId);

            return await _productRepo.CreateProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
                Weight = product.Weight,
            });
        }

        public async Task<bool> DeleteProductById(Guid productId)
        {
            return await _productRepo.DeleteProductById(productId);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepo.GetAllProducts();
        }

        public async Task<List<Product>> GetAllProductsForCategory(Guid categoryId)
        {
            await _helpers.ThrowIfCategoryDoesntExist(categoryId);

            return await _productRepo.GetAllProductsForCategory(categoryId);
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            Product? product = await _productRepo.GetProductById(productId);
            if (product == null) throw new Exception("No product found with this ID");
            return product;
        }

        public async Task<List<Product>> GetProductsBySearchString(string searchString)
        {
            return await _productRepo.GetProductsBySearchString(searchString);
        }

        public async Task<List<Product>> GetSimilarProducts(Guid productId)
        {
            Product product = await GetProductById(productId);
            List<Product> similarProducts = await GetAllProductsForCategory(product.CategoryId);
            List<Product> selectedProducts = _helpers.GetRandomElements(similarProducts, 3);
            return selectedProducts;
        }

        public async Task<Product> UpdateProduct(UpdateProductDto product)
        {
            await _helpers.ThrowIfProductDoesntExist(product.Id);
            await _helpers.ThrowIfCategoryDoesntExist(product.CategoryId);

            return await _productRepo.UpdateProduct(new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImgUrl = product.ImgUrl,
                CategoryId = product.CategoryId,
                Weight = product.Weight,
                Rating = product.Rating,
                NumberOfRatings = product.NumberOfRatings,
            });
        }
    }
}
