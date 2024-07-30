using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _appDBContext;

        public CategoryRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            _appDBContext.Categories.Add(category);
            await _appDBContext.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryById(Guid Id)
        {
            Category? categoryToDelete = await _appDBContext.Categories.FirstOrDefaultAsync(c => c.Id == Id);
            if (categoryToDelete == null) return false;
            _appDBContext.Categories.Remove(categoryToDelete);
            await _appDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _appDBContext.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category?> GetCategoryById(Guid Id)
        {
            Category? category = await _appDBContext.Categories.FirstOrDefaultAsync(c => c.Id == Id);

            if (category == null) return null;

            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            Category? categoryToUpdate = await GetCategoryById(category.Id);

            categoryToUpdate!.Name = category.Name;
            categoryToUpdate!.ImgUrl = category.ImgUrl;

            await _appDBContext.SaveChangesAsync();

            return category;
        }
    }
}
