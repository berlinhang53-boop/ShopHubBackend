using System.ComponentModel.DataAnnotations;

namespace ShopHub.API.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(300)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Phone { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [MaxLength(50)]
    public string Status { get; set; } = "Pending";

    public List<OrderItem> OrderItems { get; set; } = new();
}