using E_CommerceBackend.Data;
using E_CommerceBackend.Models;
using E_CommerceBackend.Repository.IRepository;
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

        public async Task<Category> CreateCategoryAsync(Category obj)
        {
            await _sqldb.Categories.AddAsync(obj);
            await _sqldb.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _sqldb.Categories.FirstOrDefaultAsync(o => o.CategoryId == id);
            if(category != null)
            {
                _sqldb.Categories.Remove(category);
                return (await _sqldb.SaveChangesAsync()) > 0; //_sqldb.SaveChanges returns an integer value which tells how many records were updated 
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _sqldb.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _sqldb.Categories.FirstOrDefaultAsync(o => o.CategoryId == id); 
            if (category != null)
            {
                return category;
            }
            return new Category();
        }

        public async Task<Category> UpdateCategoryAsync(Category obj)
        {
            var objFromDb = _sqldb.Categories.FirstOrDefault(o => o.CategoryId == obj.CategoryId);
            if(objFromDb is not null)
            {
                objFromDb.CategoryName = obj.CategoryName;
                _sqldb.Categories.Update(objFromDb);
                await _sqldb.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
