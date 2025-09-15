using AutoMapper;
using E_CommerceBackend.Dtos.CategoryDtos;
using E_CommerceBackend.Dtos.ProductDtos;
using E_CommerceBackend.Models;

namespace E_CommerceBackend.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
