using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Categories.Commands;
using ZooWebShopAPI.Feautures.Categories.Queries;

namespace ZooWebShopAPI.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewCategory([FromBody] AddCategoryByNameDto dto)
        {
            await _mediator.Publish(new AddNewCategoryCommand(dto));
            return Ok();
        }

        [HttpGet("id/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId([FromRoute] int categoryId)
        {
            var result = await _mediator.Send(new GetProductsByCategoryIdQuery(categoryId));
            return Ok(result);
        }

        [HttpGet("name/{categoryName}")]
        public async Task<IActionResult> GetProductsByCategoryName([FromRoute] string categoryName)
        {
            var result = await _mediator.Send(new GetProductsByCategoryNameQuery(categoryName));
            return Ok(result);
        }
    }
}
