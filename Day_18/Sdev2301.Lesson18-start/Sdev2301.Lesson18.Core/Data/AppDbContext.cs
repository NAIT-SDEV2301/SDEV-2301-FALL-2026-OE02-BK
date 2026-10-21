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
        }
    }

}
