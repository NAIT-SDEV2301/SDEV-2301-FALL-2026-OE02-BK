using Microsoft.EntityFrameworkCore;
using Sdev2301.BlazorIntro_Services.Data;
using Sdev2301.BlazorIntro_Services.Models;

namespace Sdev2301.BlazorIntro_Services.Services
{
    public class ProductService
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public ProductService(IDbContextFactory<AppDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            await using var context = await _dbFactory.CreateDbContextAsync();

            return await context.Products
                .AsNoTracking()
                .OrderBy(product => product.Name)
                .ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();

            context.Products.Add(product);
            await context.SaveChangesAsync();
        }
    }
}
