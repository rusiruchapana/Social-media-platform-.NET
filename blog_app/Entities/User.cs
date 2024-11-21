using System.ComponentModel.DataAnnotations;

namespace blog_app.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = null!;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    public string PasswordHash { get; set; } = null!;
    
    
    public string? ProfilePictureUrl { get; set; } 
    
    
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;


    public ICollection<Follow> Followers { get; set; } = new List<Follow>();
    
    
    public ICollection<Follow> Following { get; set; } = new List<Follow>();


    public ICollection<Post> Posts { get; set; } = new List<Post>();
}