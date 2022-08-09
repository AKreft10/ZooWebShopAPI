using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Products.Commands;

namespace ZooWebShopAPI.Handlers
{
    public class AddNewProductHandler : IRequestHandler<AddNewProductCommand, Product>
    {
        private readonly IDataAccess _data;

        public AddNewProductHandler(IDataAccess data)
        {
            _data = data;
        }

        public async Task<Product> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _data.AddNewProduct(request.firstName, request.price);
            return result;
        }
    }
}
