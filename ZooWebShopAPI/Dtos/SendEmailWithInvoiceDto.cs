using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Dtos
{
    public class SendEmailWithInvoiceDto
    {
        public User user { get; set; }
        public byte[] invoice { get; set; }
    }
}
