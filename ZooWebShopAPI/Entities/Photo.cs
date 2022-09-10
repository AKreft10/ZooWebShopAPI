using System.Text.Json.Serialization;

namespace ZooWebShopAPI.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        [JsonIgnore]
        public Product Product { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
