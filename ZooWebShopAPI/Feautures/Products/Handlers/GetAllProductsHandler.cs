using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Products.Queries;

namespace ZooWebShopAPI.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IDataAccess _dataAccess;

        public GetAllProductsHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dataAccess.GetAllProducts();
            return result;
        }
    }
}
