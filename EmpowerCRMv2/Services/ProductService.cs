using EmpowerCRMv2.Data;
using EmpowerCRMv2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmpowerCRMv2.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context = null)
        {
            _context = context;
        }
        public async Task AddProductItemAsync(Product item)
        {
            _context.Products.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductItemAsync(int id)
        {
            Product? productItem;

            productItem = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            
            if (productItem != null)
            {
                _context.Products.Remove(productItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProductItemsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProductItemAsync(Product item)
        {
            Product? dbItem;

            dbItem = await _context.Products.FirstOrDefaultAsync(c => c.Id == item.Id);

            if (dbItem != null)
            {
                dbItem.Name = item.Name;
                dbItem.Manufacturer = item.Manufacturer;

                await _context.SaveChangesAsync();
            }
        }
    }
}
