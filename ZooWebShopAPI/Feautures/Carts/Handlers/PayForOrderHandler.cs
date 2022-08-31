using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Feautures.Carts.Commands;
using ZooWebShopAPI.UserContext.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class PayForOrderHandler : IRequestHandler<PayForOrderCommand>
    {
        private readonly IMediator _mediator;
        private readonly IDataAccess _dataAccess;

        public PayForOrderHandler(IMediator mediator, IDataAccess dataAccess)
        {
            _mediator = mediator;
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(PayForOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(new GetUserIdCommand());
            await _dataAccess.PayForOrder(request.id, userId);
            return await Task.FromResult(Unit.Value);
        }
    }
}
