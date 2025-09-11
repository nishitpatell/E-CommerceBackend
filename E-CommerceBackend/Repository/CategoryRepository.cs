using E_CommerceBackend.Data;
using E_CommerceBackend.Models;
using E_CommerceBackend.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBackend.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlDbContext _sqldb;

        public CategoryRepository(SqlDbContext sqldb)
        {
            _sqldb = sqldb;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _sqldb.Categories.FirstOrDefaultAsync(o => o.CategoryId == id);
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _sqldb.Categories.ToListAsync();
        }

        public async Task<Category> CreateCategoryAsync(Category obj)
        {
            await _sqldb.Categories.AddAsync(obj);
            return obj;
        }

        public async Task<Category> UpdateCategoryAsync(Category obj)
        {
            var objFromDb = await _sqldb.Categories.FirstOrDefaultAsync(o => o.CategoryId == obj.CategoryId);
            if (objFromDb is not null)
            {
                objFromDb.CategoryName = obj.CategoryName;
                _sqldb.Categories.Update(objFromDb);
                return objFromDb;
            }
            return null;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _sqldb.Categories.FirstOrDefaultAsync(o => o.CategoryId == id);
            if(category != null)
            {
                _sqldb.Categories.Remove(category);
                return true;
            }
            return false;
        }
        
    }
}
