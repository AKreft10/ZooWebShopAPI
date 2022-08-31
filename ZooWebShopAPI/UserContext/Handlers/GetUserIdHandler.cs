using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.UserContext.Commands;

namespace ZooWebShopAPI.UserContext.Handlers
{
    public class GetUserIdHandler : IRequestHandler<GetUserIdCommand, int?>
    {
        private readonly IHttpContextAccessor _httpContext;

        public GetUserIdHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Task<int?> Handle(GetUserIdCommand request, CancellationToken cancellationToken)
        {
            var user = _httpContext.HttpContext.User;
            var userId = user is null ? null : (int?)int.Parse(user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return Task.FromResult(userId);
        }
    }
}
