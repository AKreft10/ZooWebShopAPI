namespace ZooWebShopAPI.Dtos
{
    public class NewUserPasswordDto
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string NewPasswordHash { get; set; } = string.Empty;
    }
}
