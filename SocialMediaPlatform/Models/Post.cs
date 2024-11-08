using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaPlatform.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    
    public User User { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    
    public DateTime CreatedAt { get; set; }
    
    
    public ICollection<Comment> Comments { get; set; }
    
    
    public ICollection<Like> Likes { get; set; }
    
    
    public ICollection<HashTag> HashTags { get; set; }
    
    
    
}