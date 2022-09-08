using MediatR;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Feautures.Categories.Queries;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Categories.Handlers
{
    public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductsByCategoryIdQuery, List<ProductModel>>
    {
        private readonly IQueryDataAccess _dataAccess;

        public GetProductsByCategoryIdHandler(IQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<ProductModel>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dataAccess.GetProductsByCategoryId(request.id);

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
