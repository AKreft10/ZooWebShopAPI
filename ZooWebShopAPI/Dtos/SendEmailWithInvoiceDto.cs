using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Dtos
{
    public class SendEmailWithInvoiceDto
    {
        public User user { get; set; }
        public byte[] invoice { get; set; }
    }
}
