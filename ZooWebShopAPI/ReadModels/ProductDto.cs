using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Models
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public List<PhotoDto> Photos { get; set; }
        public int MainPhotoId { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
