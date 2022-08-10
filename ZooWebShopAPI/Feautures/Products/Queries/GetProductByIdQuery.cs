using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Products.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<ProductModel>;
}