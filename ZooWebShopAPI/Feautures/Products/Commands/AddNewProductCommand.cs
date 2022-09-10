using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Products.Commands;

public record AddNewProductCommand(AddProductDto dto) : INotification;
