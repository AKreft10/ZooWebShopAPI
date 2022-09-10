using MediatR;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Feautures.Products.Queries;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
    {
        private readonly IQueryDataAccess _dataAccess;
        private readonly IMediator _mediator;

        public GetProductByIdHandler(IQueryDataAccess dataAccess, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _mediator = mediator;
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
