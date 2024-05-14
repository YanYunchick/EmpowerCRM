using EmpowerCRMv2.Models;

namespace EmpowerCRMv2.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductItemsAsync();
        Task AddProductItemAsync(Product item);
        Task UpdateProductItemAsync(Product item);
        Task DeleteProductItemAsync(int id);
    }
}
