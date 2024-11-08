using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaPlatform.Models;

public class Comment
{
    [Key]
    public int CommentId { get; set; }
    
    [ForeignKey("Post")]
    public int PostId { get; set; }
    
    
    public Post Post { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    
    public User User { get; set; }
    
    
    public string Content { get; set; }
    
    
    public DateTime CreatedAt { get; set; }
}