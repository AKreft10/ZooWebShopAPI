using MediatR;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Products.Commands;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Handlers;

public class AddNewProductHandler : INotificationHandler<AddNewProductCommand>
{
    private readonly ICommandDataAccess _dataAccess;

    public AddNewProductHandler(ICommandDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task Handle(AddNewProductCommand notification, CancellationToken cancellationToken)
    {
        var productToAdd = new Product()
        {
            Name = notification.dto.Name,
            OriginalPrice = notification.dto.OriginalPrice,
            Price = notification.dto.Price,
            Photos = notification.dto.Photos.Select(z => new Photo
            {
                PhotoUrl = z.PhotoUrl
            }).ToList(),
            ProductCategories = notification.dto.Categories.Select(z => new ProductCategory()
            {
                CategoryId = z.CategoryId
            }).ToList()
        };

        await _dataAccess.AddNewProduct(productToAdd);
    }
}