using System.ComponentModel.DataAnnotations;

namespace Sdev2301.BlazorIntro.Models
{
    public class ProductFormModel
    {
        [Required]
        [StringLength(20)]
        public string Sku { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Range(0, 100000)]
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

