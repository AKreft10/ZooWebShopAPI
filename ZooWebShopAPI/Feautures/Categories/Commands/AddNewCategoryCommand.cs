using MediatR;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Categories.Commands
{
    public record AddNewCategoryCommand(string name) : IRequest<CategoryDto>;
}
