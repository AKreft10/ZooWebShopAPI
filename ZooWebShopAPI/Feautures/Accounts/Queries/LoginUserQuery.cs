using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Accounts.Queries
{
    public record LoginUserQuery(LoginUserDto dto) : IRequest<string>;
}
