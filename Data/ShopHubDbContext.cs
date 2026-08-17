using Microsoft.EntityFrameworkCore;
using ShopHub.API.Models;

namespace ShopHub.API.Data;

public class ShopHubDbContext : DbContext
{
    public ShopHubDbContext(
        DbContextOptions<ShopHubDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }


    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // =========================
        // CATEGORY → PRODUCTS
        // =========================

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);


        // =========================
        // ORDER → ORDER ITEMS
        // =========================

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);


        // =========================
        // PRODUCT → ORDER ITEMS
        // =========================

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);


        // =========================
        // DECIMAL PRECISION
        // =========================

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Product>()
            .Property(p => p.Rating)
            .HasPrecision(3, 2);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.UnitPrice)
            .HasPrecision(18, 2);


        // =========================
        // CATEGORY SEED DATA
        // =========================

        modelBuilder.Entity<Category>().HasData(

            new Category
            {
                Id = 1,
                Name = "Electronics"
            },

            new Category
            {
                Id = 2,
                Name = "Fashion"
            },

            new Category
            {
                Id = 3,
                Name = "Shoes"
            },

            new Category
            {
                Id = 4,
                Name = "Accessories"
            }

        );


        // =========================
        // PRODUCT SEED DATA
        // =========================

        modelBuilder.Entity<Product>().HasData(

            new Product
            {
                Id = 1,
                Name = "iPhone 15",
                Description = "Latest Apple smartphone with powerful performance.",
                Price = 199999,
                Image = "https://images.unsplash.com/photo-1592899677977-9c10ca588bbd",
                Rating = 4.8m,
                CategoryId = 1
            },

            new Product
            {
                Id = 2,
                Name = "MacBook Air",
                Description = "Lightweight laptop with excellent performance.",
                Price = 289999,
                Image = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8",
                Rating = 4.9m,
                CategoryId = 1
            },

            new Product
            {
                Id = 3,
                Name = "Sony Headphones",
                Description = "Premium wireless headphones with clear sound.",
                Price = 45999,
                Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e",
                Rating = 4.7m,
                CategoryId = 1
            },

            new Product
            {
                Id = 4,
                Name = "Classic Hoodie",
                Description = "Comfortable premium cotton hoodie.",
                Price = 5999,
                Image = "https://images.unsplash.com/photo-1556821840-3a63f95609a7",
                Rating = 4.5m,
                CategoryId = 2
            },

            new Product
            {
                Id = 5,
                Name = "Denim Jacket",
                Description = "Classic denim jacket for everyday style.",
                Price = 7999,
                Image = "https://images.unsplash.com/photo-1551028719-00167b16eac5",
                Rating = 4.6m,
                CategoryId = 2
            },

            new Product
            {
                Id = 6,
                Name = "Nike Air Max",
                Description = "Comfortable sneakers designed for everyday use.",
                Price = 24999,
                Image = "https://images.unsplash.com/photo-1542291026-7eec264c27ff",
                Rating = 4.8m,
                CategoryId = 3
            },

            new Product
            {
                Id = 7,
                Name = "Leather Wallet",
                Description = "Premium genuine leather wallet.",
                Price = 3499,
                Image = "https://images.unsplash.com/photo-1627123424574-724758594e93",
                Rating = 4.4m,
                CategoryId = 4
            },

            new Product
            {
                Id = 8,
                Name = "Classic Watch",
                Description = "Elegant watch suitable for casual and formal wear.",
                Price = 12999,
                Image = "https://images.unsplash.com/photo-1524805444758-089113d48a6d",
                Rating = 4.7m,
                CategoryId = 4
            },

            new Product
            {
                Id = 9,
                Name = "Baggy Jeans",
                Description = "Stylish relaxed fit baggy jeans for a comfortable and modern look.",
                Price = 4999,
                Image = "https://images.unsplash.com/photo-1674075872359-a174bc7ed420?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8QmFnZ3klMjBqZWFuc3xlbnwwfHwwfHx8MA%3D%3D",
                Rating = 4.5m,
                CategoryId = 2
            },
           


            new Product
            {
                Id = 10,
                Name = "OverSized Tees",
                Description = "Stylish relaxed fit OverSized Tees for a comfortable and modern look.",
                Price = 3500,
                Image = " https://plus.unsplash.com/premium_photo-1673356301535-2cc45bcc79e4?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fE92ZXIlMjBzaXplZCUyMHRlZXN8ZW58MHx8MHx8fDA%3D\r\n",
                Rating = 4.5m,
                CategoryId = 2
            },

          


             new Product
             {
                 Id = 11,
                 Name = "Sneakers Nike",
                 Description = "Stylish relaxed fit Sneakers for a comfortable and modern look.",
                 Price = 8000,
                 Image = "  https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8U25lYWtlcnN8ZW58M",
                 Rating = 4.5m,
                 CategoryId = 3
             }
        );
    }
}