using MediatR;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Products.Queries;
using ZooWebShopAPI.Models;
using ZooWebShopAPI.ReadModels;

namespace ZooWebShopAPI.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PagedProductListResult<ProductModel>>
    {
        private readonly IQueryDataAccess _dataAccess;

        public GetAllProductsHandler(IQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<PagedProductListResult<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dataAccess.GetAllProducts(request.parameters);
            var productModels = result.Select(z => new ProductModel()
            {
                Name = z.Name,
                OriginalPrice = z.OriginalPrice,
                Price = z.Price,
                MainPhotoId = z.MainPhotoId,
                Photos = z.Photos.Select(x => new PhotoModel
                {
                    Id = x.Id,
                    PhotoUrl = x.PhotoUrl,
                }).ToList(),
                ProductCategories = z.ProductCategories.Select(c => new CategoryModel
                {
                    Id = c.CategoryId,
                    Name = c.Category.Name,
                }).ToList()
            }).ToList();

            var pagedResult = productModels
                .Skip(request.parameters.ItemsPerPage * (request.parameters.CurrentPage - 1))
                .Take(request.parameters.ItemsPerPage)
                .ToList();

            var totalItemsCount = result.Count;

            var pagedResultDto = new PagedProductListResult<ProductModel>(pagedResult, totalItemsCount, request.parameters.ItemsPerPage, request.parameters.CurrentPage);

            return pagedResultDto;
        }
    }
}
