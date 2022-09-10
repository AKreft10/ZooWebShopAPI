using MediatR;

namespace ZooWebShopAPI.Feautures.Carts.Commands
{
    public record RemoveProductFromCartCommand(int itemId, int? userId) : INotification;
}
