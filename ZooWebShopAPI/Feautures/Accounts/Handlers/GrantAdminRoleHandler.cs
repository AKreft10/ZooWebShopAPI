using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class GrantAdminRoleHandler : INotificationHandler<GrantAdminRoleCommand>
    {
        private readonly ICommandDataAccess _dataAccess;

        public GrantAdminRoleHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task Handle(GrantAdminRoleCommand notification, CancellationToken cancellationToken)
        {
            await _dataAccess.GrantAdminRole(notification.userId);
        }
    }
}
