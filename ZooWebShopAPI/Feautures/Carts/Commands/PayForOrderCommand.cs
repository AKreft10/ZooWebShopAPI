using MediatR;

namespace ZooWebShopAPI.Feautures.Carts.Commands
{
    public record PayForOrderCommand(int id) : INotification;
}
