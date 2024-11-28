using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
    
    
    public DateTime createdAt { get; set; } = DateTime.UtcNow;
}