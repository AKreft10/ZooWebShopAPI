using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Feautures.Emails.Commands;
using ZooWebShopAPI.Feautures.Products.Queries;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMediator _mediator;

        public GetProductByIdHandler(IDataAccess dataAccess, IMediator mediator)
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

            await _mediator.Send(new SendActivationEmailCommand());

            return resultProduct;
        }
    }
}
