using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,6)")]
        public decimal OriginalPrice { get; set; }
        [Column(TypeName="decimal(18,6)")]
        public decimal Price { get; set; }
        public List<Photo> Photos { get; set; }
        public int MainPhotoId { get; set; } = 1;
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
