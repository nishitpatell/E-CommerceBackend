using E_CommerceBackend.Models;
using E_CommerceBackend.Repository.IRepository;
using E_CommerceBackend.Services.IServices;

namespace E_CommerceBackend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.Categories.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Categories.GetCategoryByIdAsync(id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            var createdCategory = await _unitOfWork.Categories.CreateCategoryAsync(category);
            await _unitOfWork.SaveAsync();
            return createdCategory;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var updatedCategory = await _unitOfWork.Categories.UpdateCategoryAsync(category);
            await _unitOfWork.SaveAsync();
            return updatedCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var result = await _unitOfWork.Categories.DeleteCategoryAsync(id);
            if (result)
            {
                await _unitOfWork.SaveAsync();
            }
            return result;
        }
    }
}
