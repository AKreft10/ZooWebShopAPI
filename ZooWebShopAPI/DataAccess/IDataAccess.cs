using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.DataAccess
{
    public interface IDataAccess
    {
        Task<List<Product>> GetAllProducts();
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
    }
}