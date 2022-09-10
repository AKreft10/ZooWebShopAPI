using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Products.Commands;

namespace ZooWebShopAPI.Feautures.Products.Handlers
{
    public class EditProductHandler : INotificationHandler<EditProductCommand>
    {
        private readonly ICommandDataAccess _dataContext;

        public EditProductHandler(ICommandDataAccess dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Handle(EditProductCommand notification, CancellationToken cancellationToken)
        {
            await _dataContext.EditProduct(notification.dto);
        }
    }
}
