using FluentEmail.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Feautures.Emails.Commands;

namespace ZooWebShopAPI.Feautures.Emails.Handlers
{
    public class SendActivationEmailHandler : IRequestHandler<SendActivationEmailCommand>
    {
        private readonly IFluentEmailFactory _fluentEmail;

        public SendActivationEmailHandler(IFluentEmailFactory fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task<Unit> Handle(SendActivationEmailCommand request, CancellationToken cancellationToken)
        {
            var activateLink = "dasdsad";

            var emailToSend = await _fluentEmail
                .Create()
                .To("xd.kenzi@gmail.com")
                .Subject("test subject")
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/AccountActivationEmail.cshtml", new {activateLink})
                .SendAsync();

            Console.WriteLine(emailToSend.Successful);
            var errors = emailToSend.ErrorMessages;

            foreach (var item in errors)
                Console.WriteLine(item);

            return await Task.FromResult(Unit.Value);
        }
    }
}
