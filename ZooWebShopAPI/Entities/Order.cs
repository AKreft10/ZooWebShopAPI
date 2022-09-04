using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalPrice { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.Now;
        public DeliveryAddress DeliveryAddress { get; set; }
        public bool PaidFor { get; set; } = false;
        public int UserId { get; set; }
        public User User { get; set; }
        public string InvoiceUrl { get; set; } = string.Empty;
    }
}
