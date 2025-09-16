using E_CommerceBackend.Dtos.CategoryDtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceBackend.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string? ProductDescription { get; set; }

        public string? SpecialTag { get; set; }
        
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }


        public string? ProductImageUrl { get; set; }
    }
}
