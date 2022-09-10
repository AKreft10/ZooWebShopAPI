using MediatR;

namespace ZooWebShopAPI.Feautures.Products.Commands
{
    public record DeleteProductByIdCommand(int id) : INotification;
}
