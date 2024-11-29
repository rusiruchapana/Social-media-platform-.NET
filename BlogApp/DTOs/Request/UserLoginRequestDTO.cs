namespace BlogApp.DTOs.Request;

public class UserLoginRequestDTO
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}