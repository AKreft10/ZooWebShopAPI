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
    public class SendResetPasswordEmailHandler : IRequestHandler<SendResetPasswordCommand>
    {
        private readonly IFluentEmailFactory _fluentEmail;

        public SendResetPasswordEmailHandler(IFluentEmailFactory fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }
        public async Task<Unit> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            string resetPasswordLink = GenerateActivationLink(request.dto.Email, request.dto.ResetToken);

            var emailToSend = await _fluentEmail
                .Create()
                .To(request.dto.Email)
                .Subject("Reset your ZooShop password!")
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/ResetPasswordEmail.cshtml", new { resetPasswordLink })
                .SendAsync();

            return await Task.FromResult(Unit.Value);
        }

        private string GenerateActivationLink(string email, string token) => $"https://localhost:7280/account/reset-password?email={email}&ResetToken={token}";
    }
}
