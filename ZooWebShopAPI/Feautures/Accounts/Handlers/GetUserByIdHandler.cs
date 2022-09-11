using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Accounts.Queries;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IQueryDataAccess _dataAccess;

        public GetUserByIdHandler(IQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dataAccess.GetUserById(request.id);
        }
    }
}
