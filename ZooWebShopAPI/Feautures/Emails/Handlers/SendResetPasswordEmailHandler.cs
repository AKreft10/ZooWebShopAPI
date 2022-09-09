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
    public class SendResetPasswordEmailHandler : INotificationHandler<SendEmailResetPasswordCommand>
    {
        private readonly IFluentEmailFactory _fluentEmail;

        public SendResetPasswordEmailHandler(IFluentEmailFactory fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Handle(SendEmailResetPasswordCommand notification, CancellationToken cancellationToken)
        {
            string resetPasswordLink = await GenerateActivationLink(notification.dto.Email, notification.dto.ResetToken);

            await _fluentEmail
                .Create()
                .To(notification.dto.Email)
                .Subject("Reset your ZooShop password!")
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/ResetPasswordEmail.cshtml", new { resetPasswordLink })
                .SendAsync();
        }

        private async Task<string> GenerateActivationLink(string email, string token) => 
            await Task.FromResult($"https://localhost:7280/account/reset-password?email={email}&token={token}");
    }
}
