using Microsoft.EntityFrameworkCore;
using TodoApp.Entity;

namespace TodoApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todo { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(e =>
            {
                e.HasKey("TodoId");
                e.Property("TodoId").ValueGeneratedOnAdd();
                e.HasOne(p => p.Category)
                 .WithMany(c => c.Todos)
                 .HasForeignKey(p => p.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
