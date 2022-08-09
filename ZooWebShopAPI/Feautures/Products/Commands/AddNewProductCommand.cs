using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Feautures.Products.Commands
{
    public record AddNewProductCommand(string firstName, decimal price) : IRequest<Product>;

}
