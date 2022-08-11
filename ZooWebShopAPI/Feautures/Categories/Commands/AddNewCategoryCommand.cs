using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Categories.Commands
{
    public record AddNewCategoryCommand(AddCategoryByNameDto dto) : IRequest;
}
