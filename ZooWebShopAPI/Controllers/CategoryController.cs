using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Feautures.Categories.Commands;

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
        public async Task<IActionResult> AddNewCategory([FromBody]string category)
        {
            var result = await _mediator.Send(new AddNewCategoryCommand(category));
            return Ok(result);
        }
    }
}
