using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatform.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
     
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string passwordHash { get; set; }
    
    
    public string ProfilePictureUrl { get; set; }
    
    
    public DateTime DateCreated { get; set; }
    
    
    public virtual ICollection<Follow> Followers { get; set; }
    
    
    public virtual ICollection<Follow> Following { get; set; }
    
    
    public virtual ICollection<Post> Posts { get; set; }
    
}