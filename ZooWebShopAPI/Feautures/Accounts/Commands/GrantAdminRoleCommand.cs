using MediatR;

namespace ZooWebShopAPI.Feautures.Accounts.Commands
{
    public record GrantAdminRoleCommand(int userId) : INotification;
}
