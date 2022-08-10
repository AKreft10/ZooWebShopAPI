using MediatR;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Categories.Commands;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Categories.Handlers
{
    public class AddNewCategoryHandler : IRequestHandler<AddNewCategoryCommand, AddCategoryDto>
    {
        private readonly IDataAccess _dataAccess;

        public AddNewCategoryHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<AddCategoryDto> Handle(AddNewCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = request.name
            };

            await _dataAccess.AddNewCategory(category);

            var categoryResult = new AddCategoryDto()
            {
                Name = category.Name
            };

            return await Task.FromResult(categoryResult);
        }
    }
}
