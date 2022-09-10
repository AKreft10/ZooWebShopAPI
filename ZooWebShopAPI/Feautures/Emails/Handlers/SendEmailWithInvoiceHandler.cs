using FluentEmail.Core;
using FluentEmail.Core.Models;
using MediatR;
using ZooWebShopAPI.Feautures.Emails.Commands;

namespace ZooWebShopAPI.Feautures.Emails.Handlers
{
    public class SendEmailWithInvoiceHandler : INotificationHandler<SendEmailWithInvoiceNotification>
    {
        private readonly IFluentEmailFactory _fluentEmail;

        public SendEmailWithInvoiceHandler(IFluentEmailFactory fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Handle(SendEmailWithInvoiceNotification notification, CancellationToken cancellationToken)
        {
            var attachment = new Attachment()
            {
                ContentId = Guid.NewGuid().ToString(),
                IsInline = true,
                Filename = "Invoice.pdf",
                Data = new MemoryStream(notification.dto.invoice),
                ContentType = "application/pdf"
            };

            string resetPasswordLink = "123";

            await _fluentEmail
                .Create()
                .To(notification.dto.user.Email)
                .Subject("Invoice for your order")
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/InvoiceEmail.cshtml", new { resetPasswordLink })
                .Attach(attachment)
                .SendAsync();
        }
    }
}
