namespace ShopHub.API.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Image { get; set; } = string.Empty;

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();
    }
}
