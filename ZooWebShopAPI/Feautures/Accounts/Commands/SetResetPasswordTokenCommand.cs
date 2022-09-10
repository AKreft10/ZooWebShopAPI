using MediatR;

namespace ZooWebShopAPI.Feautures.Accounts.Commands
{
    public record SetResetPasswordToken(string email) : INotification;
}
