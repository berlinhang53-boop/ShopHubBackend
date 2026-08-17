namespace ShopHub.API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public List<OrderItemDto> Items { get; set; } = new();
    }


    public class OrderItemDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
