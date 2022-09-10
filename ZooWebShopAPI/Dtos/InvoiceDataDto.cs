using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Dtos
{
    public class InvoiceDataDto
    {
        public List<CartItem> Products { get; set; }
        public User User { get; set; }
    }
}
