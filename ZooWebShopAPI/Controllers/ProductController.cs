using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Products.Commands;
using ZooWebShopAPI.Feautures.Products.Queries;

namespace ZooWebShopAPI.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductList([FromQuery]PaginationParameters parameters)
    {
        var result = await _mediator.Send(new GetAllProductsQuery(parameters));
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [Authorize(Roles="Admin")]
    [HttpPost]
    public async Task<IActionResult> AddNewProduct([FromBody] AddProductDto dto)
    {
        await _mediator.Publish(new AddNewProductCommand(dto));
        return Ok("Item has been successfully added to the cart.");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductById([FromRoute]int id)
    {
        await _mediator.Send(new DeleteProductByIdCommand(id));
        return Ok("Item has been successfully removed from the cart.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> EditProduct([FromBody]EditProductDto dto)
    {
        await _mediator.Send(new EditProductCommand(dto));
        return Ok("Item has been successfully edited.");
    }

}