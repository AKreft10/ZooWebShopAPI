using MediatR;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Feautures.Categories.Queries;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Categories.Handlers
{
    public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductsByCategoryIdQuery, List<Product>>
    {
        private readonly IDataAccess _dataAccess;

        public GetProductsByCategoryIdHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<Product>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dataAccess.GetProductsByCategoryId(request.id);

            if (result is null)
                throw new NotFoundException("Products not found");

            var resultProduct = result.Select(x => new ProductDto
            {
                Name = x.Name,
                OriginalPrice = x.OriginalPrice,
                Price = x.Price,
                MainPhotoId = x.MainPhotoId,
                Photos = x.Photos.Select(z => new PhotoDto
                {
                    PhotoUrl = z.PhotoUrl,
                }).ToList()
            }).ToList();


            return result;
        }
    }
}
