using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PosApi.Data;
using PosApi.Models;

namespace PosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> Get()
        => await _context.Products.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> Post(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }
}