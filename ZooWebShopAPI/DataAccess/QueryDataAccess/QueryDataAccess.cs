using Microsoft.EntityFrameworkCore;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Persistence.DbContexts;

namespace ZooWebShopAPI.DataAccess.QueryDataAccess
{
    public class QueryDataAccess : IQueryDataAccess
    {
        private readonly AppDbContext _context;

        public QueryDataAccess(AppDbContext context)
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

        public async Task<User> GetUserByEmailAddress(string email)
        {
            var user = await GetUserByEmail(email);
            return await Task.FromResult(user);
        }

        public async Task<List<CartItem>> GetUsersCartItems(int? userId)
        {
            var products = await _context
                .CartProducts
                .Include(z => z.Product)
                .Where(z => z.User.Id == userId)
                .ToListAsync();

            return products;
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

        private async Task<Order?> GetOrderById(User user, int orderId)
        {
            var order = user
                .Orders
                .FirstOrDefault(x => x.Id == orderId);

            if (order == null)
                throw new NotFoundException("Order not found");

            return order;
        }
        public async Task<User> GetUserById(int? id)
        {
            var user = await _context
                .Users
                .Include(x => x.Orders)
                .Include(x => x.CartProducts)
                .FirstOrDefaultAsync(z => z.Id == id);

            if (user is null)
                throw new NotFoundException("User not found");

            return user;
        }
        private async Task<User> GetUserByEmail(string email)
        {
            var user = await _context
                .Users
                .Include(x => x.Orders)
                .Include(x => x.CartProducts)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(z => z.Email == email);

            if (user is null)
                throw new NotFoundException("User not found");

            return user;
        }

        public async Task<InvoiceDataDto> GetInvoiceDataByUserId(int? id)
        {
            var user = await GetUserById(id);
            var products = user.CartProducts.ToList();

            InvoiceDataDto invoiceData = new()
            {
                User = user,
                Products = products
            };

            return await Task.FromResult(invoiceData);
        }
    }
}
