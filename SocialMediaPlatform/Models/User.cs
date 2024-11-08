namespace SocialMediaPlatform.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string passwordHash { get; set; }
    public string ProfilePictureUrl { get; set; }
    public DateTime DateCreated { get; set; }
    public ICollection<Follow> Followers { get; set; }
    public ICollection<Follow> Following { get; set; }
    public ICollection<Post> Posts { get; set; }
    
}