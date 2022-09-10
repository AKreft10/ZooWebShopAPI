using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Feautures.Accounts.Commands
{
    public record GrantAdminRoleCommand(int userId) : INotification;
}
