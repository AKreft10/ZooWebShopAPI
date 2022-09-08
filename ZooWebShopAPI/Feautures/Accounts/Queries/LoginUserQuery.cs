using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Accounts.Queries
{
    public record LoginUserQuery(LoginUserDto dto) : IRequest<string>;
}
