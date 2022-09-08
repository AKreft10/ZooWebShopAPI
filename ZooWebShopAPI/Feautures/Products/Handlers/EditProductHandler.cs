using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Products.Commands;

namespace ZooWebShopAPI.Feautures.Products.Handlers
{
    public class EditProductHandler : IRequestHandler<EditProductCommand>
    {
        private readonly ICommandDataAccess _dataContext;

        public EditProductHandler(ICommandDataAccess dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            await _dataContext.EditProduct(request.dto);
            return await Task.FromResult(Unit.Value);
        }
    }
}
