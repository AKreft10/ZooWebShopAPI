using FluentValidation;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Validators
{
    public class AddCategoryByNameValidator : AbstractValidator<AddCategoryByNameDto>
    {
        public AddCategoryByNameValidator(ICommandDataAccess dataAccess)
        {
            RuleFor(x => x.Name)
                .Custom((value, context) =>
                {
                    var categoryNameInUse = dataAccess.CheckIfCategoryArleadyExist(value);

                    if (categoryNameInUse)
                    {
                        context.AddFailure("Name", "That category name is taken");
                    }
                });


        }


    }
}
