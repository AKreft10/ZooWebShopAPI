using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Feautures.Carts.Queries
{
    public record GetCartItemsQuery : IRequest<List<CartItem>>;
}
