using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Carts.Queries
{
    public record GetInvoiceDataQuery(int? userId) : IRequest<InvoiceDataDto>;
}
