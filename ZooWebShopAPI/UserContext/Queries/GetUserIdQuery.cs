using MediatR;

namespace ZooWebShopAPI.UserContext.Queries
{
    public record GetUserIdQuery : IRequest<int?>;
}
