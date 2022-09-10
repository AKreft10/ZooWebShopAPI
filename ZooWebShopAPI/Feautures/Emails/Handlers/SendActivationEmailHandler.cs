using FluentEmail.Core;
using MediatR;
using ZooWebShopAPI.Feautures.Emails.Commands;

namespace ZooWebShopAPI.Feautures.Emails.Handlers
{
    public class SendActivationEmailHandler : INotificationHandler<SendActivationEmailCommand>
    {
        private readonly IFluentEmailFactory _fluentEmail;

        public SendActivationEmailHandler(IFluentEmailFactory fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Handle(SendActivationEmailCommand notification, CancellationToken cancellationToken)
        {
            var activationLink = GenerateActivationLink(notification.dto.Email, notification.dto.ActivationToken);

            await _fluentEmail
                .Create()
                .To(notification.dto.Email)
                .Subject("Activate your ZooShop account!")
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/AccountActivationEmail.cshtml", new { activationLink })
                .SendAsync();
        }

        private string GenerateActivationLink(string email, string token) => $"https://localhost:7280/account/activate?email={email}&ActivationToken={token}";
    }
}
