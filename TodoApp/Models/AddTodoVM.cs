using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApp.Entity;

namespace TodoApp.Models
{
    public class AddTodoVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public bool IsComplete { get; set; }

    }
}
