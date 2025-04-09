using Microsoft.EntityFrameworkCore;
using BlazorBay.Models;

namespace BlazorBay.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, ImageUrl = "laptop.jpg" },
            new Product { Id = 2, Name = "Mouse", Price = 25.00m, ImageUrl = "mouse.jpg" },
            new Product { Id = 3, Name = "Keyboard", Price = 45.00m, ImageUrl = "keyboard.jpg" }
        );
    }
}