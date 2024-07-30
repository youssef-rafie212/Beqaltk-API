using Core.Domain.Entities;
using Core.DTO.CategoryDtos;

namespace Core.Services_contracts
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(Guid Id);
        Task<Category> CreateCategory(CreateCategoryDto category);
        Task<Category> UpdateCategory(UpdateCategoryDto category);
        Task<bool> DeleteCategoryById(Guid Id);
    }
}
