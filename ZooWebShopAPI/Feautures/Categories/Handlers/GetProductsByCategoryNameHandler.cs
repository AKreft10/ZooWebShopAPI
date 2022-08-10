using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Feautures.Categories.Queries;
using ZooWebShopAPI.Models;
using ZooWebShopAPI.ReadModels;

namespace ZooWebShopAPI.Feautures.Categories.Handlers
{


    public class GetProductsByCategoryNameHandler : IRequestHandler<GetProductsByCategoryNameQuery, List<ProductModel>>
    {
        private readonly IDataAccess _dataAccess;

        public GetProductsByCategoryNameHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<ProductModel>> Handle(GetProductsByCategoryNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _dataAccess.GetProductsByCategoryName(request.name);

            if (result is null)
                throw new NotFoundException("Products not found");

            var resultProduct = result.Select(x => new ProductModel
            {
                Name = x.Name,
                OriginalPrice = x.OriginalPrice,
                Price = x.Price,
                MainPhotoId = x.MainPhotoId,
                Photos = x.Photos.Select(z => new PhotoModel
                {
                    Id = z.Id,
                    PhotoUrl = z.PhotoUrl,
                }).ToList()
            }).ToList();

            return resultProduct;
        }
    }
}
