using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.DataAccess.QueryDataAccess
{
    public interface IQueryDataAccess
    {
        Task<List<Product>> GetAllProducts(PaginationParameters parameters);
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetProductsByCategoryId(int id);
        Task<List<Product>> GetProductsByCategoryName(string name);
        Task<User> GetUserByGivenLoginCredentials(LoginUserDto userDto);
        Task<User> GetUserByEmailAddress(string email);
        Task<List<CartItem>> GetUsersCartItems(int? userId);
        Task<User> GetUserById(int? id);
        Task<InvoiceDataDto> GetInvoiceDataByUserId(int? id);
    }
}
