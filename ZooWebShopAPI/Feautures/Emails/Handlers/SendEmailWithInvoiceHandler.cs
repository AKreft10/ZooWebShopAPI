using FluentEmail.Core;
using FluentEmail.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Feautures.Emails.Commands;
using ZooWebShopAPI.Persistence.DbContexts;
using ZooWebShopAPI.UserContext.Commands;

namespace ZooWebShopAPI.Feautures.Emails.Handlers
{
    public class SendEmailWithInvoiceHandler : IRequestHandler<SendEmailWithInvoiceCommand>
    {
        private readonly IFluentEmailFactory _fluentEmail;
        private readonly IMediator _mediator;
        private readonly IDataAccess _dataAccess;

        public SendEmailWithInvoiceHandler(IFluentEmailFactory fluentEmail, IMediator mediator, IDataAccess dataAccess)
        {
            _fluentEmail = fluentEmail;
            _mediator = mediator;
            _dataAccess = dataAccess;
        }

        public async Task<Unit> Handle(SendEmailWithInvoiceCommand request, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(new GetUserIdCommand());
            var user = await _dataAccess.GetUserById(userId);

            var attachment = new Attachment()
            {
                ContentId = Guid.NewGuid().ToString(),
                IsInline = true,
                Filename = "Invoice.pdf",
                Data = new MemoryStream(request.invoice),
                ContentType = "application/pdf"
            };

            string resetPasswordLink = "123";

            await _fluentEmail
                .Create()
                .To(user.Email)
                .Subject("Invoice for your order")
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/InvoiceEmail.cshtml", new {resetPasswordLink})
                .Attach(attachment)
                .SendAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
