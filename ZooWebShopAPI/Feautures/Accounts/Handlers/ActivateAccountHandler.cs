using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class ActivateAccountHandler : IRequestHandler<ActivateAccountCommand>
    {
        private readonly IDataAccess _dataAccess;

        public ActivateAccountHandler(IDataAccess dataAccess)
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
