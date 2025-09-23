using E_CommerceBackend.Data;
using E_CommerceBackend.Models;
using E_CommerceBackend.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBackend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlDbContext _sqldb;

        public ProductRepository(SqlDbContext sqlDb)
        {
            _sqldb = sqlDb;          
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            //return await _sqldb.Products.ToListAsync();
            return await _sqldb.Products
                .Include(p => p.Category).AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _sqldb.Products.FirstOrDefaultAsync(o => o.ProductId == id);
        }

        public async Task<Product> CreateProductAsync(Product obj)
        {
            await _sqldb.Products.AddAsync(obj);
            return obj;
        }
        
        public async Task<Product> UpdateProductAsync(Product obj)
        {
            var objFromDb = await _sqldb.Products.FirstOrDefaultAsync(o => o.ProductId == obj.ProductId);
            if (objFromDb is not null)
            {
                objFromDb.ProductName = obj.ProductName;
                objFromDb.ProductPrice = obj.ProductPrice;
                objFromDb.ProductDescription = obj.ProductDescription;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.SpecialTag = obj.SpecialTag;
                objFromDb.ProductImageUrl = obj.ProductImageUrl;
                _sqldb.Products.Update(objFromDb);
                return objFromDb;
            }
            return null;
        }
        
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _sqldb.Products.FirstOrDefaultAsync(o => o.ProductId == id);
            if (product != null)
            {
                _sqldb.Products.Remove(product);
                return true;
            }
            return false;
        }        
    }
}
