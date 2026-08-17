
using System.ComponentModel.DataAnnotations;
namespace ShopHub.API.DTOs
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, 999999999)]
        public decimal Price { get; set; }

        [Required]
        public string Image { get; set; } = string.Empty;

        [Range(0, 5)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
