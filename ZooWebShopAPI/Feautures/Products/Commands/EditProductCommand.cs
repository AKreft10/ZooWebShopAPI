using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Products.Commands
{
    public record EditProductCommand(EditProductDto dto) : INotification;
}
