using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Products.Queries;
using ZooWebShopAPI.Models;
using ZooWebShopAPI.ReadModels;

namespace ZooWebShopAPI.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductModel>>
    {
        private readonly IDataAccess _dataAccess;

        public GetAllProductsHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dataAccess.GetAllProducts();

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



            return productModels;
        }
    }
}
