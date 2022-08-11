using MediatR;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Handlers;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Products.Commands;

public record AddNewProductCommand(AddProductDto dto) : IRequest;
