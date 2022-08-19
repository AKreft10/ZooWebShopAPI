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

    public async Task<List<Product>> GetAllProducts(PaginationParameters parameters)
    {
        var baseResult = await _context
            .Products
            .Include(z => z.Photos)
            .Include(x => x.ProductCategories)
            .ThenInclude(c => c.Category)
            .ToListAsync();

        return await Task.FromResult(baseResult);
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

    public async Task ActivateAccountIfExist(ActivationEmailDto dto)
    {
        var user = await _context
            .Users
            .FirstOrDefaultAsync(z => z.Email == dto.Email);

        if (user is null || user.ActivationToken != dto.ActivationToken)
            throw new NotFoundException("User not found or invalid token.");

        user.ActivationToken = null;
        user.ActivationTime = DateTime.Now;

        await _context.SaveChangesAsync();
    }

    public async Task ResetPasswordSetToken(ResetPasswordDto dto)
    {
        var user = await _context
            .Users
            .FirstOrDefaultAsync(z => z.Email == dto.Email);

        if (user is null)
            throw new NotFoundException("User not found");

        user.ResetPasswordToken = dto.ResetToken;
        user.ResetPasswordTokenExpires = DateTime.Now.AddHours(3);

        await _context.SaveChangesAsync();
    }

    public async Task ChangeUserPassword(NewUserPasswordDto dto)
    {
        var user = await _context
            .Users
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user is null || user.ResetPasswordToken != dto.Token)
            throw new NotFoundException("User not found");

        if (user.ResetPasswordTokenExpires < DateTime.Now)
            throw new Exception("Token expired");

        user.ResetPasswordToken = null;
        user.ResetPasswordTokenExpires = null;
        user.PasswordHash = dto.NewPasswordHash;

        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmailAddress(string email)
    {
        var user = await _context
            .Users
            .FirstOrDefaultAsync(z => z.Email == email);

        if (user is null)
            throw new NotFoundException("User not found");

        return await Task.FromResult(user);
    }

}