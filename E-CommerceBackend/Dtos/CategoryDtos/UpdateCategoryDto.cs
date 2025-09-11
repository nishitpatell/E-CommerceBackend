using System.ComponentModel.DataAnnotations;

namespace E_CommerceBackend.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; } 
    }
}
