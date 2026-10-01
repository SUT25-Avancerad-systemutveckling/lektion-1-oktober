using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos => Set<Todo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("todos");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasColumnName("title");

                entity.Property(e => e.IsCompleted)
                    .HasColumnName("iscompleted");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdat");
            });
        }
    }
}
