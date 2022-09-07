using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Carts.Commands;

namespace ZooWebShopAPI.Feautures.Carts.Handlers
{
    public class GetInvoiceDataHandler : IRequestHandler<GetInvoiceDataCommand, InvoiceDataDto>
    {
        private readonly IDataAccess _dataAccess;

        public GetInvoiceDataHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<InvoiceDataDto> Handle(GetInvoiceDataCommand request, CancellationToken cancellationToken)
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
