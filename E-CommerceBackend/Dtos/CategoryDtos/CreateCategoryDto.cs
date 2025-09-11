using System.ComponentModel.DataAnnotations;

namespace E_CommerceBackend.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Category Name is required.")]
        public string CategoryName { get; set; }
    }
}
