using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Invoices.Queries;

namespace ZooWebShopAPI.Feautures.Invoices.Handlers
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
            return await _dataAccess.GetInvoiceDataByUserId(request.id);
        }
    }
}
