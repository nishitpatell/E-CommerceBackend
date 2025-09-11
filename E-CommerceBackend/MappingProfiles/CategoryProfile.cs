using AutoMapper;
using E_CommerceBackend.Models;
using E_CommerceBackend.Dtos.CategoryDtos;

namespace E_CommerceBackend.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
