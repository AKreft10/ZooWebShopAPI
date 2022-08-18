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

        [HttpPost("activate")]
        public async Task<IActionResult> ActivateAccount([FromQuery]ActivationEmailDto dto)
        {
            await _mediator.Send(new ActivateAccountCommand(dto));
            return Ok("Account has been activated!");
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> SendResetEmail([FromQuery]string email)
        {
            await _mediator.Send(new SetResetPasswordToken(email));
            return Ok("A link to reset password has been sent to your email address");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody]CreateNewPasswordDto dto)
        {
            await _mediator.Send(new ResetPasswordCommand(dto));
            return Ok("Your password has been reset successfully!");
        }
    }
}
