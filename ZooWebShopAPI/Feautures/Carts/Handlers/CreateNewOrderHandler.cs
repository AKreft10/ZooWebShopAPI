using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Carts.Commands;
using ZooWebShopAPI.UserContext.Queries;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class CreateNewOrderHandler : INotificationHandler<CreateNewOrderCommand>
    {
        private readonly IMediator _mediator;
        private readonly ICommandDataAccess _dataAccess;

        public CreateNewOrderHandler(IMediator mediator, ICommandDataAccess commandDataAccess)
        {
            _mediator = mediator;
            _dataAccess = commandDataAccess;
        }

        public async Task Handle(CreateNewOrderCommand notification, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(new GetUserIdQuery());
            await _dataAccess.AddNewOrder(userId);
        }
    }
}

