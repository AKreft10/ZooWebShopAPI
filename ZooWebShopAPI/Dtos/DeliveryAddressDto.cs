using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Dtos
{
    public class DeliveryAddressDto
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
    }
}
