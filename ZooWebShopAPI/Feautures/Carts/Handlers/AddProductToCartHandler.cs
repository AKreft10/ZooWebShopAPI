using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Carts.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class AddProductToCartHandler : INotificationHandler<AddProductToCartCommand>
    {
        private readonly ICommandDataAccess _dataAccess;
        private readonly IHttpContextAccessor _httpContext;

        public AddProductToCartHandler(ICommandDataAccess dataAccess, IHttpContextAccessor httpContext)
        {
            _dataAccess = dataAccess;
            _httpContext = httpContext;
        }

        public async Task Handle(AddProductToCartCommand notification, CancellationToken cancellationToken)
        {
            var user = _httpContext.HttpContext.User;
            int? userId = user is null ? null : (int?)int.Parse(user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var product = new CartItem()
            {
                ProductId = notification.dto.ProductId,
                Quantity = notification.dto.Quantity
            };


            await _dataAccess.AddProductToUsersCart(product, userId);
        }
    }
}
