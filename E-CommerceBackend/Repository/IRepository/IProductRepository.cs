using E_CommerceBackend.Models;

namespace E_CommerceBackend.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product obj);
        Task<Product> UpdateProductAsync(Product obj);
        Task<bool> DeleteProductAsync(int id);
    }
}
