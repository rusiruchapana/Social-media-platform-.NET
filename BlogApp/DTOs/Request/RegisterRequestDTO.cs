namespace BlogApp.DTOs.Request;

public class RegisterRequestDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}