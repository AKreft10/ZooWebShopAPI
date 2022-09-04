using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.DataAccess
{
    public interface IDataAccess
    {
        Task<List<Product>> GetAllProducts(PaginationParameters parameters);
        Task<Product?> GetProductById(int id);
        Task AddNewCategory(Category category);
        Task<List<Product>> GetProductsByCategoryId(int id);
        Task<List<Product>> GetProductsByCategoryName(string name);
        Task AddNewProduct(Product productToAdd);
        bool CheckIfCategoryArleadyExist(string categoryName);
        Task DeleteProduct(int id);
        Task EditProduct(EditProductDto dto);
        Task RegisterUser(User dto);
        bool CheckIfEmailArleadyExist(string email);
        Task<User> GetUserByGivenLoginCredentials(LoginUserDto userDto);
        Task ActivateAccountIfExist(ActivationEmailDto dto);
        Task ResetPasswordSetToken(ResetPasswordDto dto);
        Task<User> GetUserByEmailAddress(string email);
        Task ChangeUserPassword(NewUserPasswordDto dto);
        Task AddProductToUsersCart(CartItem product, int? userId);
        Task<List<CartItem>> GetUsersCartItems(int? userId);
        Task AddNewOrder(Order order, int? userId);
        Task PayForOrder(int orderId, int? userId);
        Task AddInvoiceUrlToOrder(int orderId, int? userId, string? invoiceUrl);
        Task<User> GetUserById(int? id);
        Task EmptyUsersCart(int? id);
    }
}