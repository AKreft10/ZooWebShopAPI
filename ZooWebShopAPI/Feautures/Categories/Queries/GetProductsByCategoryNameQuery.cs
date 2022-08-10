using MediatR;
using ZooWebShopAPI.Models;
using ZooWebShopAPI.ReadModels;

namespace ZooWebShopAPI.Feautures.Categories.Queries
{
    public record GetProductsByCategoryNameQuery(string name) : IRequest<List<ProductModel>>;

}
