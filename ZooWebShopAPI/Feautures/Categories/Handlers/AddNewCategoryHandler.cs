using MediatR;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Categories.Commands;
using ZooWebShopAPI.Models;

namespace ZooWebShopAPI.Feautures.Categories.Handlers
{
    public class AddNewCategoryHandler : IRequestHandler<AddNewCategoryCommand>
    {
        private readonly ICommandDataAccess _dataAccess;

        public AddNewCategoryHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Unit> Handle(AddNewCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = request.dto.Name
            };

            await _dataAccess.AddNewCategory(category);
            return await Task.FromResult(Unit.Value);
        }
    }
}
