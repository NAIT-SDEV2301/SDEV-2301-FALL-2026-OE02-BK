using Sdev2301.Lesson18.Core.Data;
using Sdev2301.Lesson18.Core.Entities;

namespace Sdev2301.Lesson18.Core.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetActiveProducts()
        {
            // TODO 1: Filter to active products, sort by Name, return a List.
            throw new NotImplementedException();
        }

        public Product CreateProduct(string sku, string name, decimal price, int categoryId)
        {
            // TODO 2: Reject blank SKU/name and price <= 0.
            // TODO 3: Reject a missing Category and duplicate SKU.
            // TODO 4: Build a Product, Add it, SaveChanges, return it.
            throw new NotImplementedException();
        }

        // Optional independent extension after completing today's core work.
        public void DeactivateProduct(int productId)
        {
            // Optional TODO: Find Product; set IsActive=false; SaveChanges.
            throw new NotImplementedException();
        }
    }
}
