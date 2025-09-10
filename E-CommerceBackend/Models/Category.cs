using System.ComponentModel.DataAnnotations;

namespace E_CommerceBackend.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter Category name..")]
        public string CategoryName { get; set; }
    }
}
