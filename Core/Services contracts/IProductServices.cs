using Core.Domain.Entities;
using Core.DTO.ProductDtos;

namespace Core.Services_contracts
{
    public interface IProductServices
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetAllProductsForCategory(Guid categoryId);
        Task<List<Product>> GetProductsBySearchString(string searchString);
        Task<List<Product>> GetSimilarProducts(Guid productId);
        Task<Product> GetProductById(Guid productId);
        Task<Product> CreateProduct(CreateproductDto product);
        Task<Product> UpdateProduct(UpdateProductDto product);
        Task<bool> DeleteProductById(Guid productId);
    }
}
