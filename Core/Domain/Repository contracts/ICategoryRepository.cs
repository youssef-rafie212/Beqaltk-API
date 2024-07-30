using Core.Domain.Entities;

namespace Core.Domain.Repository_contracts
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(Guid Id);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategoryById(Guid Id);
    }
}
