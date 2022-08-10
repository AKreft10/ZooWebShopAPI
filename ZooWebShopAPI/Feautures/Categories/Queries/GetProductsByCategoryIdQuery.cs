using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Categories.Queries
{
    public record GetProductsByCategoryIdQuery(int id) : IRequest<List<ProductModel>>;
}
