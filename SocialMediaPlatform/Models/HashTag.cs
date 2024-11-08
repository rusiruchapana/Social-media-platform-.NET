using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatform.Models;

public class HashTag
{
    [Key]
    public int HashTagId { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    
    public ICollection<Post> Posts { get; set; }
}