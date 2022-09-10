using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Accounts.Commands
{
    public record RegisterNewUserCommand(RegisterUserDto dto) : INotification;
}
