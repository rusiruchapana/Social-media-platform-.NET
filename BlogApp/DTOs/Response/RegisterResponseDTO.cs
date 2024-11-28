namespace BlogApp.DTOs.Response;

public class RegisterResponseDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime createdAt { get; set; }
}