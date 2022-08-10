using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.DataAccess
{
    public interface IDataAccess
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddNewCategory(Category category);
        Task<List<Product>> GetProductsByCategoryId(int id);
    }
}