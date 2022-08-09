using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.DataAccess
{
    public interface IDataAccess
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> AddNewProduct(string firstName, decimal price);
        Task<Product> GetProductById(int id);
        Task AddNewCategory(Category category);
    }
}