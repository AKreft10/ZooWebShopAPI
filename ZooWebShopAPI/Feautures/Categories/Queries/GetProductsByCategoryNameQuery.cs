using MediatR;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Categories.Queries
{
    public record GetProductsByCategoryNameQuery(string name) : IRequest<List<ProductModel>>;

}
