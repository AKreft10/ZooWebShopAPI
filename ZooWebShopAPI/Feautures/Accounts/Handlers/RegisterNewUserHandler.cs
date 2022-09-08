using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Accounts.Commands;
using ZooWebShopAPI.Feautures.Emails.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class RegisterNewUserHandler : INotificationHandler<RegisterNewUserCommand>
    {
        private readonly ICommandDataAccess _dataAccess;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMediator _mediator;

        public RegisterNewUserHandler(ICommandDataAccess dataAccess, IPasswordHasher<User> passwordHasher, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _passwordHasher = passwordHasher;
            _mediator = mediator;
        }

        public async Task Handle(RegisterNewUserCommand notification, CancellationToken cancellationToken)
        {
            var randomActivationToken = GenerateRandomActivationToken();

            var newUser = new User()
            {
                Email = notification.dto.Email,
                FirstName = notification.dto.FirstName,
                LastName = notification.dto.LastName,
                DateOfBirth = notification.dto.DateOfBirth,
                City = notification.dto.City,
                Street = notification.dto.Street,
                PostalCode = notification.dto.PostalCode,
                PhoneNumber = notification.dto.PhoneNumber,
                RoleId = notification.dto.RoleId,
                ActivationToken = randomActivationToken
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, notification.dto.Password);
            newUser.PasswordHash = hashedPassword;

            await _dataAccess.RegisterUser(newUser);

            var emailActivationData = new ActivationEmailDto()
            {
                Email = newUser.Email,
                ActivationToken = randomActivationToken
            };

            await _mediator.Send(new SendActivationEmailCommand(emailActivationData));
        }

        private string GenerateRandomActivationToken()
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
