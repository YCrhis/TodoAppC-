namespace TodoApp.Entity
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}
