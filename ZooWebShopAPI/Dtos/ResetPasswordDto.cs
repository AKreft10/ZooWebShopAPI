namespace ZooWebShopAPI.Dtos
{
    public class ResetPasswordDto
    {
        public string Email { get; set; } = string.Empty;
        public string ResetToken { get; set; } = string.Empty;
    }
}
