using System.ComponentModel.DataAnnotations;

namespace ShopHub.API.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MaxLength(300)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }


    public class CreateOrderItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
