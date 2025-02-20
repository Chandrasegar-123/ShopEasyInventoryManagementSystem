using Microsoft.EntityFrameworkCore;
using ShopEasyIMS.Data;
using ShopEasyIMS.DTOs;
using ShopEasyIMS.Models;

namespace ShopEasyIMS.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        // Fetch all products
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // Fetch product by ID
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        // Fetch Low Stock Products
        public async Task<List<Product>> GetLowStockProductsAsync()
        {
            return await _context.Products.Where(p => p.IsLowStock).ToListAsync();
        }

        // Fetch Out of Stock Products
        public async Task<List<Product>> GetOutOfStockProductsAsync()
        {
            return await _context.Products.Where(p => p.IsOutOfStock).ToListAsync();
        }

        // Add a new product
        public async Task<bool> AddProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                QuantityInStock = productDto.QuantityInStock,
                Price = productDto.Price,
                MinimumStockLevel = productDto.MinimumStockLevel
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        // Update an existing product
        public async Task<bool> UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.QuantityInStock = productDto.QuantityInStock;
            product.Price = productDto.Price;
            product.MinimumStockLevel = productDto.MinimumStockLevel;

            await _context.SaveChangesAsync();
            return true;
        }

        // Delete a product
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
