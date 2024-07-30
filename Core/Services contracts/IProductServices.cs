using Core.Domain.Entities;
using Core.DTO.ProductDtos;

namespace Core.Services_contracts
{
    public interface IProductServices
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid productId);
        Task<Product> CreateProduct(CreateproductDto product);
        Task<Product> UpdateProduct(UpdateProductDto product);
        Task<bool> DeleteProductById(Guid productId);
    }
}
