using System.ComponentModel.DataAnnotations;

namespace ShopEasyIMS.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int MinimumStockLevel { get; set; } = 10; // Default threshold for low stock

        // Computed Properties (Not Mapped to DB)
        public bool IsLowStock => QuantityInStock > 0 && QuantityInStock <= MinimumStockLevel;
        public bool IsOutOfStock => QuantityInStock == 0;
    }
}
