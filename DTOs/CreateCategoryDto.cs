

using System.ComponentModel.DataAnnotations;

namespace ShopHub.API.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
