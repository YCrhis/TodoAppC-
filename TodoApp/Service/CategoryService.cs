using TodoApp.Context;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using TodoApp.Entity;

namespace TodoApp.Service
{
    public class CategoryService
    {
        private readonly AppDbContext _appDbContext;

        public CategoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddCategoryService(CategoryVM category)
        {
            var newCategory = new Category()
            {
                Name = category.Name,
                Color = category.Color,
            };
            await _appDbContext.AddAsync(newCategory);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Category>> GetAllCateogiriesService()
        {
            var listCateory = await _appDbContext.Category.ToListAsync();
            return listCateory;
        }

        public async Task DeleteCategoryService(long id)
        {
            var deleteCategory = await _appDbContext.Category.FindAsync(id);
            if (deleteCategory != null)
            {
                _appDbContext.Remove(deleteCategory);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> HasTodos(long id)
        {
            return await _appDbContext.Todo.AnyAsync(t => t.CategoryId == id);
        }
    }
}
