using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Products.Commands;

namespace ZooWebShopAPI.Feautures.Products.Handlers
{
    public class DeleteProductByIdHandler : INotificationHandler<DeleteProductByIdCommand>
    {
        private readonly ICommandDataAccess _dataAccess;

        public DeleteProductByIdHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task Handle(DeleteProductByIdCommand notification, CancellationToken cancellationToken)
        {
            await _dataAccess.DeleteProduct(notification.id);
        }
    }
}
