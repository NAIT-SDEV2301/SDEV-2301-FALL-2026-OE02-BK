using Microsoft.EntityFrameworkCore;
using Sdev2301.Lesson18.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sdev2301.Lesson18.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            // TODO (after break): Explicitly configure Category and Product.
            // 1. HasKey for both entities.
            // 2. Category.Name required, max 50 characters.
            // 3. Product.Sku required/max 20 and Name required/max 100.
            // 4. Unique index for Product.Sku.
            // 5. HasOne/WithMany/HasForeignKey for CategoryId.
            // Optional: restrict deletion of a Category with Products.
            // 1. Configure the primary key for Category.
            model.Entity<Category>()
                .HasKey(c => c.Id);

            // 2. Category.Name is required and limited to 50 characters.
            model.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            // 3. Configure the primary key for Product.
            model.Entity<Product>()
                .HasKey(p => p.Id);

            // 4. Product.Sku is required and limited to 20 characters.
            model.Entity<Product>()
                .Property(p => p.Sku)
                .IsRequired()
                .HasMaxLength(20);

            // 5. Product.Name is required and limited to 100 characters.
            model.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            // 6. Product.Sku must be unique.
            model.Entity<Product>()
                .HasIndex(p => p.Sku)
                .IsUnique();

            // 7. Configure the Category-Product relationship.
            model.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
