using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaPlatform.Models;

public class Like
{
    [Key]
    public int LikeId { get; set; }
    
    [ForeignKey("Post")]
    public int PostId { get; set; }
    
    
    public Post Post { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    
    public User User { get; set; }
}