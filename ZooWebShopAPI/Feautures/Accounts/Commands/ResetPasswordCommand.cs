using MediatR;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Feautures.Accounts.Commands
{
    public record ResetPasswordCommand(CreateNewPasswordDto dto, User user) : INotification;
}
