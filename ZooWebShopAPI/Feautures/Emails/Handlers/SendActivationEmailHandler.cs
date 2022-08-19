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
            var activationLink = GenerateActivationLink(request.dto.Email, request.dto.ActivationToken);

            var emailToSend = await _fluentEmail
                .Create()
                .To(request.dto.Email)
                .Subject("Activate your ZooShop account!")
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/AccountActivationEmail.cshtml", new {activationLink})
                .SendAsync();

            return await Task.FromResult(Unit.Value);
        }

        private string GenerateActivationLink(string email, string token) => $"https://localhost:7280/account/activate?email={email}&ActivationToken={token}";
    }
}
