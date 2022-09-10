using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Emails.Commands
{
    public record SendEmailWithInvoiceNotification(SendEmailWithInvoiceDto dto) : INotification;
}
