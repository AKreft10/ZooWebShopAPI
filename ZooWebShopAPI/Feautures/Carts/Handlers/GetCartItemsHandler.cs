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

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, List<CartItem>>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IHttpContextAccessor _httpContext;

        public GetCartItemsHandler(IDataAccess dataAccess, IHttpContextAccessor httpContext)
        {
            _dataAccess = dataAccess;
            _httpContext = httpContext;
        }
        public async Task<List<CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            var user = _httpContext.HttpContext.User;
            int? userId = user is null ? null : (int?)int.Parse(user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var items = await _dataAccess.GetUsersCartItems(userId);
            return items;
        }
    }
}
