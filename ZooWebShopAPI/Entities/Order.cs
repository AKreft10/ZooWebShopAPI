using System.ComponentModel.DataAnnotations.Schema;

namespace ZooWebShopAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalPrice { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.Now;
        public bool PaidFor { get; set; } = false;
        public int UserId { get; set; }
        public User User { get; set; }
        public string InvoiceUrl { get; set; } = string.Empty;
    }
}
