using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.DTO.CategoryDtos;
using Core.Helpers;
using Core.Services_contracts;

namespace Core.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly ServicesHelpers _helpers;

        public CategoryServices(ICategoryRepository categoryRepo,
                ServicesHelpers helpers)
        {
            _categoryRepo = categoryRepo;
            _helpers = helpers;
        }

        public async Task<Category> CreateCategory(CreateCategoryDto category)
        {
            Category createdCategory = await _categoryRepo.CreateCategory(new Category()
            {
                Id = new Guid(),
                Name = category.Name,
                ImgUrl = category.ImgUrl
            });

            return createdCategory;
        }

        public async Task<bool> DeleteCategoryById(Guid Id)
        {
            Category? category = await _categoryRepo.GetCategoryById(Id);

            if (category == null) return false;

            bool deleted = await _categoryRepo.DeleteCategoryById(Id);

            return deleted;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepo.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(Guid Id)
        {
            await _helpers.ThrowIfCategoryDoesntExist(Id);
            return (await _categoryRepo.GetCategoryById(Id))!;
        }

        public async Task<Category> UpdateCategory(UpdateCategoryDto category)
        {
            await _helpers.ThrowIfCategoryDoesntExist(category.Id);

            Category updatedCategory = await _categoryRepo.UpdateCategory(new Category()
            {
                Id = category.Id,
                Name = category.Name,
                ImgUrl = category.ImgUrl
            });

            return updatedCategory;
        }
    }
}
