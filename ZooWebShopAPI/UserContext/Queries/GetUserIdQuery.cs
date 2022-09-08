using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.UserContext.Queries
{
    public record GetUserIdQuery : IRequest<int?>;
}
