using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Feautures.Products.Queries;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
    {
        private readonly IDataAccess _dataAccess;

        public GetProductByIdHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<ProductModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dataAccess.GetProductById(request.id);

            if (result is null)
                throw new NotFoundException("Product not found.");

            var resultProduct = new ProductModel()
            {
                Name = result.Name,
                OriginalPrice = result.OriginalPrice,
                Price = result.Price,
                MainPhotoId = result.MainPhotoId,

                Photos = result.Photos.Select(z => new PhotoModel
                {
                    Id = z.Id,
                    PhotoUrl = z.PhotoUrl
                }).ToList(),
            };

            return resultProduct;
        }
    }
}
