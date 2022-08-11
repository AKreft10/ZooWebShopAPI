using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Validators
{
    public class EditProductValidator : AbstractValidator<EditProductDto>
    {
        public EditProductValidator()
        {
            RuleFor(z => z.Name)
                .MinimumLength(6);

            RuleFor(z => z.OriginalPrice)
                .LessThanOrEqualTo(x => x.Price);

            RuleFor(z => z.Price)
                .NotEmpty()
                .NotNull();

            RuleFor(z => z.MainPhotoId)
                .NotEmpty()
                .NotNull();

        }
    }
}
