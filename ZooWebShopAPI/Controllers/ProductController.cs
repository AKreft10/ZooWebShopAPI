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
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Product>> GetTestResult()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return result;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewProduct([FromBody] AddProductDto dto)
    {
        await _mediator.Send(new AddNewProductCommand(dto));
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductById([FromRoute]int id)
    {
        await _mediator.Send(new DeleteProductByIdCommand(id));
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> EditProduct([FromBody]EditProductDto dto)
    {
        await _mediator.Send(new EditProductCommand(dto));
        return Ok();
    }

}