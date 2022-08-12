using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser([FromBody] RegisterUserDto dto)
        {
            await _mediator.Send(new RegisterNewUserCommand(dto));
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            string token = await _mediator.Send(new LoginUserCommand(dto));
            return Ok(token);
        }
    }
}
