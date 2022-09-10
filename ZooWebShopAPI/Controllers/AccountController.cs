using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Accounts.Commands;
using ZooWebShopAPI.Feautures.Accounts.Queries;

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
            await _mediator.Publish(new RegisterNewUserCommand(dto));
            return Ok("Email with activation link has been sent. Click the button to activate your account.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            string token = await _mediator.Send(new LoginUserQuery(dto));
            return Ok(token);
        }

        [HttpPost("activate")]
        public async Task<IActionResult> ActivateAccount([FromQuery] ActivationEmailDto dto)
        {
            await _mediator.Publish(new ActivateAccountCommand(dto));
            return Ok("Account has been activated!");
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> SendResetEmail([FromQuery] string email)
        {
            await _mediator.Publish(new SetResetPasswordToken(email));
            return Ok("A link to reset password has been sent to your email address");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromQuery]string email, string token, [FromBody] NewPasswordDto dto)
        {
            var user = await _mediator.Send(new GetUserByEmailAddressQuery(email));

            var passwordRecoveryDto = new CreateNewPasswordDto()
            {
                Email = email,
                ResetToken = token,
                NewPassword = dto.NewPasword,
                ConfirmNewPassword = dto.ConfirmNewPassword
            };

            await _mediator.Publish(new ResetPasswordCommand(passwordRecoveryDto, user));
            return Ok("Your password has been reset successfully!");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("grant-admin-role")]
        public async Task<IActionResult> GrantAdminRole([FromQuery]int userId)
        {
            await _mediator.Publish(new GrantAdminRoleCommand(userId));
            return Ok();
        }
    }
}
