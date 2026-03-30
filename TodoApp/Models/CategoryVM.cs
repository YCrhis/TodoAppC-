using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class CategoryVM
    {
        [Required]
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
