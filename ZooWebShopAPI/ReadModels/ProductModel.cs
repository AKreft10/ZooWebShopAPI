using ZooWebShopAPI.ReadModels;

namespace ZooWebShopAPI.Models
{
    public class ProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public List<PhotoModel> Photos { get; set; }
        public int MainPhotoId { get; set; }
        public List<CategoryModel> ProductCategories { get; set; }
    }
}
