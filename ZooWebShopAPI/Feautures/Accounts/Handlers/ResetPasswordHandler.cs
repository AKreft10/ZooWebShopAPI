using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMediator _mediator;

        public ResetPasswordHandler(IDataAccess dataAccess, IPasswordHasher<User> passwordHasher)
        {
            _dataAccess = dataAccess;
            _passwordHasher = passwordHasher;
        }
        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _dataAccess.GetUserByEmailAddress(request.dto.Email);

            var newUserPassword = new NewUserPasswordDto()
            {
                Email = request.dto.Email,
                Token = request.dto.ResetToken,
                NewPasswordHash = _passwordHasher.HashPassword(user, request.dto.NewPassword)
            };

            await _dataAccess.ChangeUserPassword(newUserPassword);

            return await Task.FromResult(Unit.Value);
        }
    }
}
