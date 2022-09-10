using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Invoices.Commands
{
    public record GenerateInvoiceCommand(InvoiceDataDto dto) : IRequest<byte[]>;

}
