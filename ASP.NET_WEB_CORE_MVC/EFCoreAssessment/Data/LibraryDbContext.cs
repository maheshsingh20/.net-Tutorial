using EFCoreAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssessment.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision for Price
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(18, 2);

            // Seed initial data
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Clean Code", Author = "Robert C. Martin", Price = 45.99m },
                new Book { BookId = 2, Title = "Design Patterns", Author = "GoF", Price = 54.99m },
                new Book { BookId = 3, Title = "Refactoring", Author = "Martin Fowler", Price = 49.99m }
            );
        }
    }
}
