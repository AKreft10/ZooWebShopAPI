using MediatR;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.Feautures.Invoices.Commands;

namespace ZooWebShopAPI.Feautures.Invoices.Handlers
{
    public class AddInvoiceUrlToOrderHandler : INotificationHandler<AddInvoiceUrlToOrderNotification>
    {
        private readonly ICommandDataAccess _dataAccess;

        public AddInvoiceUrlToOrderHandler(ICommandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task Handle(AddInvoiceUrlToOrderNotification notification, CancellationToken cancellationToken)
        {
            await _dataAccess.AddInvoiceUrlToOrder(notification.dto);
        }
    }
}
