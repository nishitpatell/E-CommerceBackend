using System.ComponentModel.DataAnnotations;

namespace E_CommerceBackend.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        [Required]
        public string ProductName { get; set; }
        [Range(0.01, 100000)]
        public decimal ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? SpecialTag { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string? ProductImageUrl { get; set; }
    }
}
