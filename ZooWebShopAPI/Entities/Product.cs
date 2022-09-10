using System.ComponentModel.DataAnnotations.Schema;

namespace ZooWebShopAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public List<Photo> Photos { get; set; }
        public int MainPhotoId { get; set; } = 1;
        public List<ProductCategory> ProductCategories { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
