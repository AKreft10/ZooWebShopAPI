using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Feautures.Carts.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class RemoveProductFromCartHandler : IRequestHandler<RemoveProductFromCartCommand>
    {
        private readonly IDataAccess _dataAccess;

        public RemoveProductFromCartHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Unit> Handle(RemoveProductFromCartCommand request, CancellationToken cancellationToken)
        {
            await _dataAccess.RemoveItemFromUsersCart(request.itemId, request.userId);
            return await Task.FromResult(Unit.Value);
        }
    }
}
