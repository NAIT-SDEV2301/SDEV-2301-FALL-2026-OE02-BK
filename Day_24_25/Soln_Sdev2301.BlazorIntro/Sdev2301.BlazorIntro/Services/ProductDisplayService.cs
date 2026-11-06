using Sdev2301.BlazorIntro_Services.Models;

namespace Sdev2301.BlazorIntro_Services.Services
{
    public class ProductDisplayService
    {
        public string GetStatus(Product product)
        {
            return product.IsActive ? "Active" : "Inactive";
        }

        public string GetSummary(Product product)
        {
            return $"{product.Sku} - {product.Name} ({product.Price:C})";
        }
    }
}
