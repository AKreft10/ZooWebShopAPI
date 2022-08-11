using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Feautures.Products.Commands;

namespace ZooWebShopAPI.Feautures.Products.Handlers
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdCommand>
    {
        private readonly IDataAccess _dataAccess;

        public DeleteProductByIdHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Unit> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            await _dataAccess.DeleteProduct(request.id);
            return await Task.FromResult(Unit.Value);

        }
    }
}
