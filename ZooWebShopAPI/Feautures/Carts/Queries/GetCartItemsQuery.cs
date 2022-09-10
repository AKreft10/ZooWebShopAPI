using MediatR;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Feautures.Carts.Queries
{
    public record GetCartItemsQuery : IRequest<List<CartItem>>;
}
