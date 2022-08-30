using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Carts.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class AddProductToCartHandler : IRequestHandler<AddProductToCartCommand>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IHttpContextAccessor _httpContext;

        public AddProductToCartHandler(IDataAccess dataAccess, IHttpContextAccessor httpContext)
        {
            _dataAccess = dataAccess;
            _httpContext = httpContext;
        }
        public async Task<Unit> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            var user = _httpContext.HttpContext.User;
            int? userId = user is null ? null : (int?)int.Parse(user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var product = new CartItem()
            {
                ProductId = request.dto.ProductId,
                Quantity = request.dto.Quantity
            };


            await _dataAccess.AddProductToUsersCart(product, userId);
            return await Task.FromResult(Unit.Value);
        }
    }
}
