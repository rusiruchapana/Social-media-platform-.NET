namespace BlogApp.DTOs.Response;

public class UserLoginResponseDTO
{
    public string Token { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}