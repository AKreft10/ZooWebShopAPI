using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator(ICommandDataAccess dataAccess)
        {
            RuleFor(z => z.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .Custom((value, context) =>
                {
                    var emailInUseArleady = dataAccess.CheckIfEmailArleadyExist(value);
                    if(emailInUseArleady)
                    {
                        context.AddFailure("That email is arleady in use");
                    }
                });

            RuleFor(z => z.Password)
                .MinimumLength(6);

            RuleFor(z => z.ConfirmPassword)
                .Equal(z => z.Password);
        }
    }
}
