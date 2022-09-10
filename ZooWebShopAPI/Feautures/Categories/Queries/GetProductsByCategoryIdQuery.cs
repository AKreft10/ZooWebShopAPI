using MediatR;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Categories.Queries
{
    public record GetProductsByCategoryIdQuery(int id) : IRequest<List<ProductModel>>;
}
