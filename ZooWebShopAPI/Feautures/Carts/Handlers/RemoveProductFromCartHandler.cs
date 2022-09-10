using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Carts.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class RemoveProductFromCartHandler : INotificationHandler<RemoveProductFromCartCommand>
    {
        private readonly ICommandDataAccess _dataAccess;

        public RemoveProductFromCartHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task Handle(RemoveProductFromCartCommand notification, CancellationToken cancellationToken)
        {
            await _dataAccess.RemoveItemFromUsersCart(notification.itemId, notification.userId);
        }
    }
}
