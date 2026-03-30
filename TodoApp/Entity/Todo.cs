using System.ComponentModel.DataAnnotations;

namespace TodoApp.Entity
{
    public class Todo
    {
        public long TodoId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public long CategoryId { get; set; }
        public Category? Category { get; set; } = null;
    
    }
}
