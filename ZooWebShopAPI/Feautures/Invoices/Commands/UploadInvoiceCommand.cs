using MediatR;

namespace ZooWebShopAPI.Feautures.Invoices.Commands
{
    public record UploadInvoiceCommand(byte[] invoice) : IRequest<string?>;
}
