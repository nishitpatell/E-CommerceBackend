using AutoMapper;
using E_CommerceBackend.Dtos.ProductDtos;
using E_CommerceBackend.Dtos.ProductDtos;
using E_CommerceBackend.Models;
using E_CommerceBackend.Repository.IRepository;
using E_CommerceBackend.Services.IServices;

namespace E_CommerceBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Product = await _unitOfWork.Products.GetProductByIdAsync(id);
            return _mapper.Map<ProductDto>(Product);
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var Product = _mapper.Map<Product>(createProductDto);
            var createdProduct = await _unitOfWork.Products.CreateProductAsync(Product);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProductDto>(createdProduct);
        }

        public async Task<ProductDto> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var Product = _mapper.Map<Product>(updateProductDto);
            var updatedProduct = await _unitOfWork.Products.UpdateProductAsync(Product);
            await _unitOfWork.SaveAsync();
            return updatedProduct == null ? null : _mapper.Map<ProductDto>(updatedProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var result = await _unitOfWork.Products.DeleteProductAsync(id);
            if (result)
            {
                await _unitOfWork.SaveAsync();
            }
            return result;
        }
    }
}
