using Microsoft.EntityFrameworkCore;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Persistence.DbContexts;

namespace ZooWebShopAPI.DataAccess.CommandDataAccess;

public class CommandDataAccess : ICommandDataAccess
{
    private readonly AppDbContext _context;

    public CommandDataAccess(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddNewCategory(Category category)
    {
        await _context.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task AddNewProduct(Product productToAdd)
    {
        await _context.Products.AddAsync(productToAdd);
        await _context.SaveChangesAsync();
    }

    public bool CheckIfCategoryArleadyExist(string categoryName)
    {
        if (_context.Categories.Any(z => z.Name == categoryName))
            return true;
        else
            return false;
    }

    public async Task DeleteProduct(int id)
    {
        var productTodelete = await _context
            .Products
            .FirstOrDefaultAsync(z => z.Id == id);

        if (productTodelete != null)

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
            return true;
        else
            return false;
    }

    public async Task ActivateAccountIfExist(ActivationEmailDto dto)
    {
        var user = await GetUserByEmail(dto.Email);
        user.ActivationToken = null;
        user.ActivationTime = DateTime.Now;
        await _context.SaveChangesAsync();
    }

    public async Task ResetPasswordSetToken(ResetPasswordDto dto)
    {
        var user = await GetUserByEmail(dto.Email);
        user.ResetPasswordToken = dto.ResetToken;
        user.ResetPasswordTokenExpires = DateTime.Now.AddHours(3);
        await _context.SaveChangesAsync();
    }

    public async Task ChangeUserPassword(NewUserPasswordDto dto)
    {
        var user = await GetUserByEmail(dto.Email);

        if (user.ResetPasswordTokenExpires < DateTime.Now)
            throw new Exception("Token expired");

        user.ResetPasswordToken = null;
        user.ResetPasswordTokenExpires = null;
        user.PasswordHash = dto.NewPasswordHash;
        await _context.SaveChangesAsync();
    }

    public async Task AddProductToUsersCart(CartItem product, int? userId)
    {
        var user = await GetUserById(userId);

        if (user.CartProducts.Any(z => z.ProductId == product.ProductId))
            user.CartProducts.SingleOrDefault(x => x.ProductId == product.ProductId).Quantity += product.Quantity;
        else
            user.CartProducts.Add(product);

        await _context.SaveChangesAsync();
    }

    public async Task AddNewOrder(int? userId)
    {
        var user = await GetUserById(userId);

        decimal finalPrice = 0;

        var userCartItems = user
            .CartProducts
            .ToList();

        foreach (var item in userCartItems)
        {
            finalPrice += item.Product.Price * item.Quantity;
        }

        var order = new Order()
        {
            FinalPrice = finalPrice,
            CartItems = userCartItems
        };

        user.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task PayForOrder(int orderId, int? userId)
    {
        var user = await GetUserById(userId);

        var order = user
            .Orders
            .FirstOrDefault(x => x.Id == orderId);

        if (order == null)
            throw new NotFoundException("Order not found");

        order.PaidFor = true;
        await _context.SaveChangesAsync();
    }

    public async Task AddInvoiceUrlToOrder(AddInvoiceToOrderDto dto)
    {
        var user = await GetUserById(dto.userId);
        var order = await GetOrderById(user, dto.orderId);

        if (order == null)
            throw new NotFoundException("OrderNotFound");

        order.InvoiceUrl = dto.invoiceUrl;
        await _context.SaveChangesAsync();
    }

    public async Task EmptyUsersCart(int? id)
    {
        var user = await GetUserById(id);
        user.CartProducts.Clear();
        await _context.SaveChangesAsync();
    }

    public async Task RemoveItemFromUsersCart(int itemId, int? userId)
    {
        var user = await GetUserById(userId);
        var product = user.CartProducts.FirstOrDefault(z => z.ProductId == itemId);

        if (product == null)
            throw new NotFoundException("Product not found");

        user.CartProducts.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task ResetUsersPassword(NewUserPasswordDto dto)
    {
        var user = await GetUserByEmail(dto.Email);

        if (user.ResetPasswordToken != dto.Token || user.ResetPasswordTokenExpires > DateTime.Now)
            throw new Exception("Invalid token");

        user.ResetPasswordTokenExpires = null;
        user.ResetPasswordToken = null;
        user.PasswordHash = dto.NewPasswordHash;
    }

    public async Task GrantAdminRole(int userId)
    {
        var user = await GetUserById(userId);
        user.RoleId = 2;
        await _context.SaveChangesAsync();
    }

    private async Task<Order?> GetOrderById(User user, int orderId)
    {
        var order = user
            .Orders
            .FirstOrDefault(x => x.Id == orderId);

        if (order == null)
            throw new NotFoundException("Order not found");

        return await Task.FromResult(order);
    }
    public async Task<User> GetUserById(int? id)
    {
        var user = await _context
            .Users
            .Include(x => x.Orders)
            .Include(x => x.CartProducts)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(z => z.Id == id);

        if (user is null)
            throw new NotFoundException("User not found");

        return user;
    }
    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _context
            .Users
            .Include(x => x.Orders)
            .Include(x => x.CartProducts)
            .ThenInclude(x => x.Product)
            .Include(x => x.Role)
            .FirstOrDefaultAsync(z => z.Email == email);

        if (user is null)
            throw new NotFoundException("User not found");

        return user;
    }


}