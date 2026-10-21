using Sdev2301.Lesson18.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sdev2301.Lesson18.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetActiveProducts_ReturnsOnlyActiveProductsSortedByName()
        {
            var (context, connection) = DbTestHelper.Create();
            using (context) using (connection)
            {
                var category = new Category { Name = "Electronics" };
                context.Categories.Add(category);
                context.SaveChanges();
                context.Products.AddRange(
                    new Product { Sku = "MOU", Name = "Mouse", Price = 25m, IsActive = true, CategoryId = category.Id },
                    new Product { Sku = "OLD", Name = "Old Mouse", Price = 10m, IsActive = false, CategoryId = category.Id },
                    new Product { Sku = "KEY", Name = "Keyboard", Price = 50m, IsActive = true, CategoryId = category.Id });
                context.SaveChanges();

                // TODO 5: Act: create ProductService and call GetActiveProducts.
                // TODO 6: Assert the names are Keyboard, Mouse in that order.
                throw new NotImplementedException();
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateProduct_InvalidPrice_Throws(decimal price)
        {
            var (context, connection) = DbTestHelper.Create();
            using (context) using (connection)
            {
                // TODO 7: Construct service and use Assert.Throws.
                throw new NotImplementedException();
            }
        }
    }

}
