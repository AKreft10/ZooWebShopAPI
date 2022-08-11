using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Feautures.Products.Commands
{
    public record DeleteProductByIdCommand(int id) : IRequest;
}
