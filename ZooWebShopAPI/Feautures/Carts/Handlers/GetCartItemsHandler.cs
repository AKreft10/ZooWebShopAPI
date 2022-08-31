using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Carts.Queries;
using ZooWebShopAPI.UserContext.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, List<CartItem>>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMediator _mediator;

        public GetCartItemsHandler(IDataAccess dataAccess, IHttpContextAccessor httpContext, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _httpContext = httpContext;
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
