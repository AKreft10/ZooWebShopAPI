using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class GetUserByEmailAddressHandler : IRequestHandler<GetUserByEmailAddressCommand, User>
    {
        private readonly ICommandDataAccess _dataAccess;

        public GetUserByEmailAddressHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<User> Handle(GetUserByEmailAddressCommand request, CancellationToken cancellationToken)
        {
            return await _dataAccess.GetUserByEmail(request.emailAddress);
        }
    }
}
