using System.ComponentModel.DataAnnotations;

namespace E_CommerceBackend.Dtos.ProductDtos
{
    public class ProductImageUploadDto
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
