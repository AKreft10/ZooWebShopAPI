namespace ZooWebShopAPI.Dtos
{
    public class AddInvoiceToOrderDto
    {
        public int orderId { get; set; }
        public int? userId { get; set; }
        public string? invoiceUrl { get; set; }
    }
}
