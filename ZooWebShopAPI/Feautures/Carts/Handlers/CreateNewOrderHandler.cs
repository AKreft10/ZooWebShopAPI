using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Carts.Commands;
using ZooWebShopAPI.UserContext.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class CreateNewOrderHandler : IRequestHandler<CreateNewOrderCommand>
    {
        private readonly IMediator _mediator;
        private readonly ICommandDataAccess _dataAccess;

        public CreateNewOrderHandler(IMediator mediator, ICommandDataAccess commandDataAccess)
        {
            _mediator = mediator;
            _dataAccess = commandDataAccess;
        }

        public async Task<Unit> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(new GetUserIdCommand());

            var order = new Order()
            {
                DeliveryAddress = new DeliveryAddress()
                {
                    City = request.dto.City,
                    PostalCode = request.dto.PostalCode,
                    Street = request.dto.Street,
                }
            };
            await _dataAccess.AddNewOrder(order, userId);
            return await Task.FromResult(Unit.Value);
        }


    }
}

