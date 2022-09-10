using MediatR;
using System.Security.Claims;
using ZooWebShopAPI.UserContext.Queries;

namespace ZooWebShopAPI.UserContext.Handlers
{
    public class GetUserIdHandler : IRequestHandler<GetUserIdQuery, int?>
    {
        private readonly IHttpContextAccessor _httpContext;

        public GetUserIdHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Task<int?> Handle(GetUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = _httpContext.HttpContext.User;
            var userId = user is null ? null : (int?)int.Parse(user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return Task.FromResult(userId);
        }
    }
}
