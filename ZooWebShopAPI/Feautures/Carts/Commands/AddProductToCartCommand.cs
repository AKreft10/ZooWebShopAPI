using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Carts.Commands
{
    public record AddProductToCartCommand(AddProductToCartDto dto) : INotification;
}
