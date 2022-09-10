using MediatR;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Products.Queries
{
    public record GetAllProductsQuery(PaginationParameters parameters) : IRequest<PagedProductListResult<ProductModel>>;
}
