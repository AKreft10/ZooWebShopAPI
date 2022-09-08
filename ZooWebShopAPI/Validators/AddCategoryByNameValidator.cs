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
    public class AddCategoryByNameValidator : AbstractValidator<AddCategoryByNameDto>
    {
        public AddCategoryByNameValidator(ICommandDataAccess dataAccess)
        {
            RuleFor(x => x.Name)
                .Custom((value, context) =>
                {
                    var categoryNameInUse = dataAccess.CheckIfCategoryArleadyExist(value);

                    if(categoryNameInUse)
                    {
                        context.AddFailure("Name", "That category name is taken");
                    }
                });


        }


    }
}
