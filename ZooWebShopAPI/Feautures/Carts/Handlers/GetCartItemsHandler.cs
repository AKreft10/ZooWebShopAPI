using MediatR;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Carts.Queries;
using ZooWebShopAPI.UserContext.Queries;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, List<CartItem>>
    {
        private readonly IQueryDataAccess _dataAccess;
        private readonly IMediator _mediator;

        public GetCartItemsHandler(IQueryDataAccess dataAccess, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _mediator = mediator;
        }
        public async Task<List<CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(new GetUserIdQuery());
            var items = await _dataAccess.GetUsersCartItems(userId);
            return items;
        }
    }
}
