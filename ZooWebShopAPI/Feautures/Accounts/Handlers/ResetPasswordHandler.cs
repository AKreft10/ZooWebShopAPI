using MediatR;
using Microsoft.AspNetCore.Identity;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class ResetPasswordHandler : INotificationHandler<ResetPasswordCommand>
    {
        private readonly ICommandDataAccess _dataAccess;
        private readonly IPasswordHasher<User> _passwordHasher;

        public ResetPasswordHandler(ICommandDataAccess dataAccess, IPasswordHasher<User> passwordHasher)
        {
            _dataAccess = dataAccess;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(ResetPasswordCommand notification, CancellationToken cancellationToken)
        {
            var newUserPassword = new NewUserPasswordDto()
            {
                Email = notification.dto.Email,
                Token = notification.dto.ResetToken,
                NewPasswordHash = _passwordHasher.HashPassword(notification.user, notification.dto.NewPassword)
            };

            await _dataAccess.ChangeUserPassword(newUserPassword);
        }
    }
}
