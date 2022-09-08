using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Accounts.Commands;
using ZooWebShopAPI.Feautures.Emails.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class SetResetPasswordTokenHandler : INotificationHandler<SetResetPasswordToken>
    {
        private readonly ICommandDataAccess _dataAccess;
        private readonly IMediator _mediator;

        public SetResetPasswordTokenHandler(ICommandDataAccess dataAccess, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _mediator = mediator;
        }

        public async Task Handle(SetResetPasswordToken notification, CancellationToken cancellationToken)
        {
            var resetTokenDto = new ResetPasswordDto()
            {
                Email = notification.email,
                ResetToken = GenerateRandomResetToken(),
            };
            await _dataAccess.ResetPasswordSetToken(resetTokenDto);
            await _mediator.Publish(new SendEmailResetPasswordCommand(resetTokenDto));
        }

        private string GenerateRandomResetToken()
        {
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[64];
                cryptoProvider.GetBytes(bytes);

                string secureRandomString = Convert.ToHexString(bytes);

                return secureRandomString;
            }
        }
    }
}
