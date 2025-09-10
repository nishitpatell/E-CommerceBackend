using E_CommerceBackend.Models;

namespace E_CommerceBackend.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateCategoryAsync(Category obj);
        public Task<Category> UpdateCategoryAsync(Category obj);
        public Task<bool> DeleteCategoryAsync(int id);
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
