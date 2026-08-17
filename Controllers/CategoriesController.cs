using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHub.API.Data;
using ShopHub.API.DTOs;
using ShopHub.API.Models;

namespace ShopHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ShopHubDbContext _context;

    public CategoriesController(ShopHubDbContext context)
    {
        _context = context;
    }


    // ==========================================
    // GET: api/categories
    // ==========================================

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

        return Ok(categories);
    }


    // ==========================================
    // GET: api/categories/1
    // ==========================================

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = await _context.Categories
            .Where(c => c.Id == id)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .FirstOrDefaultAsync();

        if (category == null)
        {
            return NotFound(new
            {
                message = "Category not found."
            });
        }

        return Ok(category);
    }


    // ==========================================
    // POST: api/categories
    // ==========================================

    [HttpPost]
    public async Task<IActionResult> CreateCategory(
        CreateCategoryDto dto)
    {
        // Check duplicate category

        var categoryExists = await _context.Categories
            .AnyAsync(c => c.Name.ToLower() == dto.Name.ToLower());

        if (categoryExists)
        {
            return BadRequest(new
            {
                message = "Category already exists."
            });
        }


        // Create category

        var category = new Category
        {
            Name = dto.Name
        };


        _context.Categories.Add(category);

        await _context.SaveChangesAsync();


        // Return created category

        var createdCategory = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };


        return CreatedAtAction(
            nameof(GetCategory),
            new { id = category.Id },
            createdCategory
        );
    }


    // ==========================================
    // PUT: api/categories/1
    // ==========================================

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(
        int id,
        CreateCategoryDto dto)
    {
        var category = await _context.Categories
            .FindAsync(id);

        if (category == null)
        {
            return NotFound(new
            {
                message = "Category not found."
            });
        }


        // Check duplicate name

        var duplicateExists = await _context.Categories
            .AnyAsync(c =>
                c.Id != id &&
                c.Name.ToLower() == dto.Name.ToLower());

        if (duplicateExists)
        {
            return BadRequest(new
            {
                message = "Another category with this name already exists."
            });
        }


        // Update

        category.Name = dto.Name;

        await _context.SaveChangesAsync();


        return Ok(new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        });
    }


    // ==========================================
    // DELETE: api/categories/1
    // ==========================================

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound(new
            {
                message = "Category not found."
            });
        }


        // Don't delete category if products exist

        if (category.Products.Any())
        {
            return BadRequest(new
            {
                message = "Cannot delete category because it contains products."
            });
        }


        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();


        return Ok(new
        {
            message = "Category deleted successfully."
        });
    }
}