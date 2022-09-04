using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Feautures.Invoices.Commands
{
    public record UploadInvoiceCommand(byte[] invoice) : IRequest<string?>;
}
