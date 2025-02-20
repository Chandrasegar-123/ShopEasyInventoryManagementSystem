using System.ComponentModel.DataAnnotations;

namespace ShopEasyIMS.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int MinimumStockLevel { get; set; }

        public bool IsLowStock => QuantityInStock > 0 && QuantityInStock <= MinimumStockLevel;
        public bool IsOutOfStock => QuantityInStock == 0;
    }
}
