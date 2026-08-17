using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHub.API.Data;
using ShopHub.API.DTOs;
using ShopHub.API.Models;

namespace ShopHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ShopHubDbContext _context;

    public OrdersController(ShopHubDbContext context)
    {
        _context = context;
    }


    // ==========================================
    // POST: api/orders
    // ==========================================

    [HttpPost]
    public async Task<IActionResult> CreateOrder(
        CreateOrderDto dto)
    {
        // ------------------------------------------
        // Check items
        // ------------------------------------------

        if (dto.Items == null || dto.Items.Count == 0)
        {
            return BadRequest(new
            {
                message = "Order must contain at least one product."
            });
        }


        // ------------------------------------------
        // Get product IDs
        // ------------------------------------------

        var productIds = dto.Items
            .Select(i => i.ProductId)
            .Distinct()
            .ToList();


        // ------------------------------------------
        // Get products from database
        // ------------------------------------------

        var products = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();


        // ------------------------------------------
        // Check all products exist
        // ------------------------------------------

        if (products.Count != productIds.Count)
        {
            return BadRequest(new
            {
                message = "One or more products do not exist."
            });
        }


        // ------------------------------------------
        // Create Order
        // ------------------------------------------

        var order = new Order
        {
            CustomerName = dto.CustomerName,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address,
            OrderDate = DateTime.UtcNow,
            Status = "Pending"
        };


        decimal totalAmount = 0;


        // ------------------------------------------
        // Create Order Items
        // ------------------------------------------

        foreach (var item in dto.Items)
        {
            var product = products
                .First(p => p.Id == item.ProductId);


            var orderItem = new OrderItem
            {
                ProductId = product.Id,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            };


            order.OrderItems.Add(orderItem);


            totalAmount += product.Price * item.Quantity;
        }


        // ------------------------------------------
        // Set total
        // ------------------------------------------

        order.TotalAmount = totalAmount;


        // ------------------------------------------
        // Save Order
        // ------------------------------------------

        _context.Orders.Add(order);

        await _context.SaveChangesAsync();


        // ------------------------------------------
        // Return response
        // ------------------------------------------

        return CreatedAtAction(
            nameof(GetOrder),
            new { id = order.Id },
            new
            {
                message = "Order created successfully.",
                orderId = order.Id,
                totalAmount = order.TotalAmount,
                status = order.Status
            }
        );
    }


    // ==========================================
    // GET: api/orders/1
    // ==========================================

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);


        if (order == null)
        {
            return NotFound(new
            {
                message = "Order not found."
            });
        }


        var orderDto = new OrderDto
        {
            Id = order.Id,

            CustomerName = order.CustomerName,

            Email = order.Email,

            Phone = order.Phone,

            Address = order.Address,

            TotalAmount = order.TotalAmount,

            OrderDate = order.OrderDate,

            Status = order.Status,

            Items = order.OrderItems
                .Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,

                    ProductName = oi.Product.Name,

                    Image = oi.Product.Image,

                    Quantity = oi.Quantity,

                    UnitPrice = oi.UnitPrice,

                    TotalPrice = oi.UnitPrice * oi.Quantity
                })
                .ToList()
        };


        return Ok(orderDto);
    }
}