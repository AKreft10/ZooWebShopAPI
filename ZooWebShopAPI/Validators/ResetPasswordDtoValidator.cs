using FluentValidation;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Validators
{
    public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator()
        {
            RuleFor(z => z.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(z => z.ResetToken)
                .NotNull();
        }
    }
}
