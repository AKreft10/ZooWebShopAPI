using System.Text.Json.Serialization;

namespace ZooWebShopAPI.Entities
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
