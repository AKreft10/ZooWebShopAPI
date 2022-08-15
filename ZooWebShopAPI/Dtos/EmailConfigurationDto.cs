using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Dtos
{
    public class EmailConfigurationDto
    {
        public string EmailFrom { get; set; } = string.Empty;
        public string EmailSender { get; set; } = string.Empty;
        public string EmailPassword { get; set; } = string.Empty;
        public int EmailPort { get; set; }
        public string EmailServer { get; set; } = string.Empty;
    }
}
