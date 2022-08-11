using Microsoft.EntityFrameworkCore;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Persistence.DbContexts;

namespace ZooWebShopAPI.DataAccess;

public class DataAccess : IDataAccess
{
    private readonly AppDbContext _context;

    public DataAccess(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        var result = await _context
            .Products
            .ToListAsync();

        return result;
    }

    public async Task<Product?> GetProductById(int id)
    {
        var product = await _context
            .Products
            .Include(z => z.Photos)
            .FirstOrDefaultAsync(z => z.Id == id);

        return product;
    }

    public async Task AddNewCategory(Category category)
    {
        await _context.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetProductsByCategoryId(int id)
    {
        var result = await _context
            .ProductCategory
            .Include(z => z.Product)
            .ThenInclude(z => z.Photos)
            .Where(z => z.CategoryId == id)
            .Select(z => z.Product)
            .ToListAsync();

        return result;
    }

    public async Task<List<Product>> GetProductsByCategoryName(string name)
    {
        var result = await _context
            .ProductCategory
            .Include(z => z.Product)
            .ThenInclude(z => z.Photos)
            .Where(z => z.Category.Name.ToLower() == name.ToLower())
            .Select(z => z.Product)
            .ToListAsync();

        return result;
    }

    public async Task AddNewProduct(Product productToAdd)
    {
        await _context.Products.AddAsync(productToAdd);
        await _context.SaveChangesAsync();
    }

    public bool CheckIfCategoryArleadyExist(string categoryName)
    {
        if (_context.Categories.Any(z => z.Name == categoryName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task DeleteProduct(int id)
    {
        var productTodelete = await _context
            .Products
            .FirstOrDefaultAsync(z => z.Id == id);

        if(productTodelete != null)

        _context.Products.Remove(productTodelete);
        await _context.SaveChangesAsync();
    }
}