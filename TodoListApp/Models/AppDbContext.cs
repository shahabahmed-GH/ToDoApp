using Microsoft.EntityFrameworkCore;
namespace TodoListApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
