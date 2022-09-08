using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Feautures.Accounts.Commands
{
    public record GetUserByEmailAddressCommand(string emailAddress) : IRequest<User>;

}
