using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Dtos
{
    public class InvoiceDataDto
    {
        public List<string> Products { get; set; }
        public User User { get; set; }
    }
}
