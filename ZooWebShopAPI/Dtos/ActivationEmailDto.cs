using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Dtos
{
    public class ActivationEmailDto
    {
        public string Email { get; set; } = string.Empty;
        public string ActivationToken { get; set; } = string.Empty;

    }
}
