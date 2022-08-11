using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Validators
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryValidator(IDataAccess dataAccess)
        {
            RuleFor(x => x.Name)
                .Custom(async (value, context) =>
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
