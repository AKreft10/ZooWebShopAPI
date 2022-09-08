using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Carts.Commands;
using ZooWebShopAPI.UserContext.Queries;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class PayForOrderHandler : INotificationHandler<PayForOrderCommand>
    {
        private readonly IMediator _mediator;
        private readonly ICommandDataAccess _dataAccess;

        public PayForOrderHandler(IMediator mediator, ICommandDataAccess dataAccess)
        {
            _mediator = mediator;
            _dataAccess = dataAccess;
        }

        public async Task Handle(PayForOrderCommand notification, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(new GetUserIdQuery()); // TO REMOVE
            await _dataAccess.PayForOrder(notification.id, userId);
        }
    }
}
