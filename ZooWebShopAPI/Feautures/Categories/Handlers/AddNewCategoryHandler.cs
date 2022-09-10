using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Categories.Commands;

namespace ZooWebShopAPI.Feautures.Categories.Handlers
{
    public class AddNewCategoryHandler : INotificationHandler<AddNewCategoryCommand>
    {
        private readonly ICommandDataAccess _dataAccess;

        public AddNewCategoryHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task Handle(AddNewCategoryCommand notification, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = notification.dto.Name
            };

            await _dataAccess.AddNewCategory(category);
        }
    }
}
