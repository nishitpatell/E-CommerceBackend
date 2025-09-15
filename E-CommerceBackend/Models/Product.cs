using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceBackend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Range(0.01, 100000)]
        public decimal ProductPrice { get; set; }

        public string? ProductDescription {  get; set; }

        public string? SpecialTag { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public string? ProductImageUrl { get; set; }    
    }
}
