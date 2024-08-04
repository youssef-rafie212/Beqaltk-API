using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _db;

        public ProductRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductById(Guid productId)
        {
            Product? product = await GetProductById(productId);
            if (product == null) return false;
            _db.Products.Remove(product);
            await _db.SaveChangesAsync(true);
            return true;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            return await _db.Products.Include(p => p.Reviews).FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<Product>> GetProductsBySearchString(string searchString)
        {
            return await _db.Products.Where(p => p.Name!.ToLower().Contains(searchString.ToLower())).ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            Product? productToUpdate = await GetProductById(product.Id);
            productToUpdate!.Name = product.Name;
            productToUpdate!.Price = product.Price;
            productToUpdate!.Weight = product.Weight;
            productToUpdate!.CategoryId = product.CategoryId;
            productToUpdate!.ImgUrl = product.ImgUrl;
            productToUpdate!.Rating = product.Rating;
            productToUpdate!.NumberOfRatings = product.NumberOfRatings;

            await _db.SaveChangesAsync();

            return product;
        }
    }
}
