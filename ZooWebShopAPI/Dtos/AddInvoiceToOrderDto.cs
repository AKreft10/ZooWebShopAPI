using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Dtos
{
    public class AddInvoiceToOrderDto
    { 
        public int orderId { get; set; }
        public int? userId { get; set; }
        public string? invoiceUrl { get; set; }
    }
}
