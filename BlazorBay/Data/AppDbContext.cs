using Microsoft.EntityFrameworkCore;
using BlazorBay.Models;

namespace BlazorBay.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, ImageUrl = "laptop.jpg" },
                new Product { Id = 2, Name = "Mouse", Price = 25.00m, ImageUrl = "mouse.jpg" },
                new Product { Id = 3, Name = "Keyboard", Price = 45.00m, ImageUrl = "keyboard.jpg" }
            );

            // Optional: Add constraints (if needed)
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Role).IsRequired();
        }
    }
}
