using MediatR;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Products.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<ProductModel>;
}