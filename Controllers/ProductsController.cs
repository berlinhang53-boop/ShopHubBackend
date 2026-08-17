using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHub.API.Data;
using ShopHub.API.DTOs;
using ShopHub.API.Models;

namespace ShopHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ShopHubDbContext _context;

    public ProductsController(ShopHubDbContext context)
    {
        _context = context;
    }


    // ==========================================
    // GET: api/products
    // ==========================================

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {

        

        var products = await _context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
                Rating = p.Rating,
                CategoryId = p.CategoryId,
                CategoryName = p.Category!.Name
            })
            .ToListAsync();

        return Ok(products);
    }


    // ==========================================
    // GET: api/products/1
    // ==========================================

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _context.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
                Rating = p.Rating,
                CategoryId = p.CategoryId,
                CategoryName = p.Category!.Name
            })
            .FirstOrDefaultAsync();

        if (product == null)
        {
            return NotFound(new
            {
                message = "Product not found"
            });
        }

        return Ok(product);
    }


    // ==========================================
    // POST: api/products
    // ==========================================

    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        CreateProductDto dto)
    {
        // Check category exists

        var categoryExists = await _context.Categories
            .AnyAsync(c => c.Id == dto.CategoryId);

        if (!categoryExists)
        {
            return BadRequest(new
            {
                message = "Category does not exist."
            });
        }


        // Create Product

        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Image = dto.Image,
            Rating = dto.Rating,
            CategoryId = dto.CategoryId
        };


        // Add to database

        _context.Products.Add(product);

        await _context.SaveChangesAsync();


        // Return created product

        var createdProduct = await _context.Products
            .Where(p => p.Id == product.Id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
                Rating = p.Rating,
                CategoryId = p.CategoryId,
                CategoryName = p.Category!.Name
            })
            .FirstAsync();


        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            createdProduct
        );
    }
    // ==========================================
    // PUT: api/products/1
    // ==========================================





















    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(
        int id,
        CreateProductDto dto)
    {
        // Find product

        var product = await _context.Products
            .FindAsync(id);

        if (product == null)
        {
            return NotFound(new
            {
                message = "Product not found."
            });
        }


        // Check category

        var categoryExists = await _context.Categories
            .AnyAsync(c => c.Id == dto.CategoryId);

        if (!categoryExists)
        {
            return BadRequest(new
            {
                message = "Category does not exist."
            });
        }


        // Update product

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Image = dto.Image;
        product.Rating = dto.Rating;
        product.CategoryId = dto.CategoryId;


        // Save changes

        await _context.SaveChangesAsync();


        // Return updated product

        var updatedProduct = await _context.Products
            .Where(p => p.Id == product.Id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
                Rating = p.Rating,
                CategoryId = p.CategoryId,
                CategoryName = p.Category!.Name
            })
            .FirstAsync();


        return Ok(updatedProduct);
    }

















    // ==========================================
    // DELETE: api/products/1
    // ==========================================

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        // Find product

        var product = await _context.Products
            .FindAsync(id);

        if (product == null)
        {
            return NotFound(new
            {
                message = "Product not found."
            });
        }


        // Delete product

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();


        return Ok(new
        {
            message = "Product deleted successfully."
        });
    }
}