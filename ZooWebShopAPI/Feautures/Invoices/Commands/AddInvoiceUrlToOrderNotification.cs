using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Invoices.Commands
{
    public record AddInvoiceUrlToOrderNotification(AddInvoiceToOrderDto dto) : INotification;
}
