using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Carts.Queries;
using ZooWebShopAPI.UserContext.Commands;

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
            var userId = await _mediator.Send(new GetUserIdCommand());
            var items = await _dataAccess.GetUsersCartItems(userId);
            return items;
        }
    }
}
