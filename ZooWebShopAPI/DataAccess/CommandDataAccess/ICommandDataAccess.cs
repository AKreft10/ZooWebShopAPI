using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.DataAccess.CommandDataAccess
{
    public interface ICommandDataAccess
    {
        Task AddNewCategory(Category category);
        Task AddNewProduct(Product productToAdd);
        bool CheckIfCategoryArleadyExist(string categoryName);
        Task DeleteProduct(int id);
        Task EditProduct(EditProductDto dto);
        Task RegisterUser(User dto);
        bool CheckIfEmailArleadyExist(string email);
        Task ActivateAccountIfExist(ActivationEmailDto dto);
        Task ResetPasswordSetToken(ResetPasswordDto dto);
        Task ChangeUserPassword(NewUserPasswordDto dto);
        Task AddProductToUsersCart(CartItem product, int? userId);
        Task AddNewOrder(Order order, int? userId);
        Task PayForOrder(int orderId, int? userId);
        Task AddInvoiceUrlToOrder(AddInvoiceToOrderDto dto);
        Task EmptyUsersCart(int? id);
        Task RemoveItemFromUsersCart(int itemId, int? userId);
        Task<User> GetUserByEmail(string email);
    }
}