using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Models
{
    public class ProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public List<PhotoModel> Photos { get; set; }
        public int MainPhotoId { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
