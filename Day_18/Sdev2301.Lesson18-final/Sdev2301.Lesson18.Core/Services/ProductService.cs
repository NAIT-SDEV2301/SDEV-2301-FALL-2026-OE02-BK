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
            //throw new NotImplementedException();
            // TODO 1: Filter active products, sort by Name, return a List.
            return _context.Products
                .Where(p => p.IsActive)
                .OrderBy(p => p.Name)
                .ToList();
        }

        public Product CreateProduct(string sku, string name, decimal price, int categoryId)
        {
            // TODO 2: Reject blank SKU/name and price <= 0.
            // TODO 3: Reject a missing Category and duplicate SKU.
            // TODO 4: Build a Product, Add it, SaveChanges, return it.
            //throw new NotImplementedException();
            // TODO 2: Reject blank SKU/name and price <= 0.
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentException(
                    "SKU cannot be blank.", nameof(sku));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Product name cannot be blank.", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(price), "Price must be greater than zero.");
            }

            // TODO 3: Reject a missing Category and duplicate SKU.
            bool categoryExists = _context.Categories
                .Any(c => c.Id == categoryId);

            if (!categoryExists)
            {
                throw new ArgumentException(
                    "The specified category does not exist.",
                    nameof(categoryId));
            }

            sku = sku.Trim();
            name = name.Trim();

            bool skuExists = _context.Products
                .Any(p => p.Sku == sku);

            if (skuExists)
            {
                throw new ArgumentException(
                    "A product with this SKU already exists.",
                    nameof(sku));
            }

            // TODO 4: Build a Product, Add it, SaveChanges, return it.
            var product = new Product
            {
                Sku = sku,
                Name = name,
                Price = price,
                CategoryId = categoryId,
                IsActive = true
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;


        }

        // Optional independent extension after completing today's core work.
        public void DeactivateProduct(int productId)
        {
            // Optional TODO: Find Product; set IsActive=false; SaveChanges.
            // throw new NotImplementedException();
            var product = _context.Products
                 .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new ArgumentException(
                    "Product not found.", nameof(productId));
            }

            product.IsActive = false;

            _context.SaveChanges();
        }
    }
}
