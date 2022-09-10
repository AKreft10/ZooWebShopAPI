using MediatR;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Feautures.Accounts.Queries
{
    public record GetUserByEmailAddressQuery(string emailAddress) : IRequest<User>;

}
