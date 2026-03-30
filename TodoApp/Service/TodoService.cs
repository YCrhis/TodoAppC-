using Microsoft.EntityFrameworkCore;
using TodoApp.Context;
using TodoApp.Entity;
using TodoApp.Models;

namespace TodoApp.Service
{
    public class TodoService
    {
        private readonly AppDbContext _appDbContext;

        public TodoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task InsertTodoService(AddTodoVM todo)
        {
            var todoItem = new Todo()
            {
                Name = todo.Name,
                Description = todo.Description,
                IsComplete = todo.IsComplete,
                CategoryId = todo.CategoryId
            };
            await _appDbContext.AddAsync(todoItem);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Todo>> GetAllTodosService()
        {
            return await _appDbContext.Todo.Include(c => c.Category).ToListAsync();
        }

        public async Task DeleteTodoService(long id)
        {
            var todoItem = await _appDbContext.Todo.FindAsync(id);
            if (todoItem != null)
            {
                _appDbContext.Remove(todoItem);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateService(long id)
        {
            var todoItem = await _appDbContext.Todo.FindAsync(id);
            if (todoItem != null)
            {
                todoItem.IsComplete = !todoItem.IsComplete;
            }
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Todo> GetTodoByIdService(long id)
        {
            return await _appDbContext.Todo.FindAsync(id);
        }
    }
}
