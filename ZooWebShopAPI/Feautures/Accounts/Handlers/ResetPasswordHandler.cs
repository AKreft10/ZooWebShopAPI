using MediatR;
using Microsoft.AspNetCore.Identity;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly ICommandDataAccess _dataAccess;
        private readonly IPasswordHasher<User> _passwordHasher;

        public ResetPasswordHandler(ICommandDataAccess dataAccess, IPasswordHasher<User> passwordHasher)
        {
            _dataAccess = dataAccess;
            _passwordHasher = passwordHasher;
        }
        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var newUserPassword = new NewUserPasswordDto()
            {
                Email = request.dto.Email,
                Token = request.dto.ResetToken,
                NewPasswordHash = _passwordHasher.HashPassword(request.user, request.dto.NewPassword)
            };

            await _dataAccess.ChangeUserPassword(newUserPassword);

            return await Task.FromResult(Unit.Value);
        }
    }
}
