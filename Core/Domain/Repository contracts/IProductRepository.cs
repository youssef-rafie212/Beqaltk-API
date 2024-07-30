using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsBySearchString(string searchString);
        Task<Product?> GetProductById(Guid productId);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProductById(Guid productId);
    }
}
