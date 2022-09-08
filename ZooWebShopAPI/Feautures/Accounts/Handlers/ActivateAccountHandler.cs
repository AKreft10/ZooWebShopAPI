﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class ActivateAccountHandler : IRequestHandler<ActivateAccountCommand>
    {
        private readonly ICommandDataAccess _dataAccess;

        public ActivateAccountHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(ActivateAccountCommand request, CancellationToken cancellationToken)
        {
            await _dataAccess.ActivateAccountIfExist(request.dto);
            return await Task.FromResult(Unit.Value);
        }
    }
}
