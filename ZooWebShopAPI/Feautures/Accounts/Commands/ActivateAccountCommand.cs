using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Accounts.Commands
{
    public record ActivateAccountCommand(ActivationEmailDto dto) : INotification;
}
