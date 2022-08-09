using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public Product Product { get; set; }
    }
}
