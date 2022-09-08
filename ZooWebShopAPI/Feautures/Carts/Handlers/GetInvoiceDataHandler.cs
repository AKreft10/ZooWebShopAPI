using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Carts.Queries;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class GetInvoiceDataHandler : IRequestHandler<GetInvoiceDataQuery, InvoiceDataDto>
    {
        private readonly IQueryDataAccess _dataAccess;

        public GetInvoiceDataHandler(IQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<InvoiceDataDto> Handle(GetInvoiceDataQuery request, CancellationToken cancellationToken)
        {
            var invoiceData = new InvoiceDataDto()
            {
                User = await _dataAccess.GetUserById(request.userId),
                Products = await _dataAccess.GetUsersCartItems(request.userId)
            };

            return await Task.FromResult(invoiceData);
        }
    }
}
