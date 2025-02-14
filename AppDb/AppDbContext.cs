using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.AppDb
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }  // Add DbSet for ToDoItem

    
    }
}
