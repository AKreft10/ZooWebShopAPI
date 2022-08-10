using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
