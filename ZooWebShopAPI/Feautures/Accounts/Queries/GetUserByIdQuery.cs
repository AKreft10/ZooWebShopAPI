using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Feautures.Accounts.Queries
{
    public record GetUserByIdQuery(int? id) : IRequest<User>;

}
