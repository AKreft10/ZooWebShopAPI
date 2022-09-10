using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class ActivateAccountHandler : INotificationHandler<ActivateAccountCommand>
    {
        private readonly ICommandDataAccess _dataAccess;

        public ActivateAccountHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task Handle(ActivateAccountCommand notification, CancellationToken cancellationToken)
        {
            await _dataAccess.ActivateAccountIfExist(notification.dto);
        }
    }
}
