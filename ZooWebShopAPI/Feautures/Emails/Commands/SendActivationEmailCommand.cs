using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Emails.Commands
{
    public record SendActivationEmailCommand(ActivationEmailDto dto) : INotification;
}
