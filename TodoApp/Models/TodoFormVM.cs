using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApp.Entity;

namespace TodoApp.Models
{
    public class TodoFormVM
    {
        public AddCategoryVM AddCategory { get; set; } = new();
        public AddTodoVM AddTodo { get; set; } = new();

        public List<Category> Categories { get; set; } = new();
        public List<Todo> Todos { get; set; } = new();
        public List<SelectListItem> CategoriesOption { get; set; } = new();
    }
}
