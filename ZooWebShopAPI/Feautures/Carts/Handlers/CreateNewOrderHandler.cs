using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Carts.Commands;
using ZooWebShopAPI.UserContext.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class CreateNewOrderHandler : IRequestHandler<CreateNewOrderCommand>
    {
        private readonly IMediator _mediator;
        private readonly IDataAccess _dataAccess;

        public CreateNewOrderHandler(IMediator mediator, IDataAccess dataAccess)
        {
            _mediator = mediator;
            _dataAccess = dataAccess;
        }

        public async Task<Unit> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(new GetUserIdCommand());
            var cartItems = await _dataAccess.GetUsersCartItems(userId);
            await _dataAccess.EmptyUsersCart(userId);

            decimal finalPrice = 0;

            foreach (var item in cartItems)
            {
                finalPrice += item.Product.Price * item.Quantity;
            }

            var order = new Order()
            {
                CartItems = cartItems,
                FinalPrice = finalPrice,
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

