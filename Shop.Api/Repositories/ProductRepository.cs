using Microsoft.EntityFrameworkCore;
using Shop.Api.Context;
using Shop.Api.Entities;

namespace Shop.Api.Repositories;

public class ProductRepository : IProductRepository
{
    // This class will access the database 

    private readonly AppDbContext _context; // dependency injection
    
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Product> GetItem(int id)
    {
        var product = await _context.Products
                        .Include(c => c.Category)            
                        .FirstOrDefaultAsync(c => c.Id == id);

        return product;
    }

    public async Task<IEnumerable<Product>> GetItems()
    {
        var products = await _context.Products
                        .Include(c => c.Category)
                        .ToListAsync();

        return products;
    }

    public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
    {
        var productsByCategory = await _context.Products
                        .Include(c => c.Category)
                        .Where(c => c.CategoryId == id)
                        .ToListAsync();

        return productsByCategory;
    }
}
