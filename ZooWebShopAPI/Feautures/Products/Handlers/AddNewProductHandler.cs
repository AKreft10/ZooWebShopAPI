using MediatR;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Products.Commands;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Handlers;

public class AddNewProductHandler : IRequestHandler<AddNewProductCommand>
{
    private readonly ICommandDataAccess _dataAccess;

    public AddNewProductHandler(ICommandDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }


    public async Task<Unit> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
    {
        var productToAdd = new Product()
        {
            Name = request.dto.Name,
            OriginalPrice = request.dto.OriginalPrice,
            Price = request.dto.Price,
            Photos = request.dto.Photos.Select(z => new Photo
            {
                PhotoUrl = z.PhotoUrl
            }).ToList(),
            ProductCategories = request.dto.Categories.Select(z => new ProductCategory()
            {
                CategoryId = z.CategoryId
            }).ToList()
        };

        await _dataAccess.AddNewProduct(productToAdd);
        return await Task.FromResult(Unit.Value);
    }
}