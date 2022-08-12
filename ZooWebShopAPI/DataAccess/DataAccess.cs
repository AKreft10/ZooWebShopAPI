using Microsoft.EntityFrameworkCore;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Exceptions;
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

    public async Task EditProduct(EditProductDto dto)
    {
        var productToEdit = await _context
            .Products
            .FirstOrDefaultAsync(z => z.Id == dto.Id);

        if (productToEdit == null)
            throw new NotFoundException("Product not found");

        productToEdit.Name = dto.Name;
        productToEdit.OriginalPrice = dto.OriginalPrice;
        productToEdit.Price = dto.Price;
        productToEdit.Photos = dto.Photos.Select(z => new Photo
        {
            PhotoUrl = z.PhotoUrl
        }).ToList();
            productToEdit.ProductCategories = dto.ProductCategories.Select(z => new ProductCategory()
            {
                CategoryId = z.CategoryId
            }).ToList();

        await _context.SaveChangesAsync();

    }
    public async Task RegisterUser(User dto)
    {
        await _context.Users.AddAsync(dto);
        await _context.SaveChangesAsync();
    }

    public bool CheckIfEmailArleadyExist(string email)
    {
        if (_context.Users.Any(z => z.Email == email))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<User> GetUserByGivenLoginCredentials(LoginUserDto userDto)
    {
        var user = await _context
            .Users
            .Include(z => z.Role)
            .FirstOrDefaultAsync(z => z.Email == userDto.Email);

        if (user is null)
            throw new BadRequestException("Invalid username or password");

        return await Task.FromResult(user);
    }
}