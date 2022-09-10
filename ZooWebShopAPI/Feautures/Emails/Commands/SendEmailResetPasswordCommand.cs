using MediatR;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Emails.Commands
{
    public record SendEmailResetPasswordCommand(ResetPasswordDto dto) : INotification;
}
