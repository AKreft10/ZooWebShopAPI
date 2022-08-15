using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Accounts.Commands;
using ZooWebShopAPI.Feautures.Emails.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class RegisterNewUserHandler : IRequestHandler<RegisterNewUserCommand>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMediator _mediator;

        public RegisterNewUserHandler(IDataAccess dataAccess, IPasswordHasher<User> passwordHasher, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _passwordHasher = passwordHasher;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User()
            {
                Email = request.dto.Email,
                FirstName = request.dto.FirstName,
                LastName = request.dto.LastName,
                DateOfBirth = request.dto.DateOfBirth,
                City = request.dto.City,
                Street = request.dto.Street,
                PostalCode = request.dto.PostalCode,
                PhoneNumber = request.dto.PhoneNumber,
                RoleId = request.dto.RoleId
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, request.dto.Password);
            newUser.PasswordHash = hashedPassword;

            await _dataAccess.RegisterUser(newUser);

            await _mediator.Send(new SendActivationEmailCommand());

            return await Task.FromResult(Unit.Value);
        }
    }
}
