using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_app.Entities;

public class Post
{
    [Key]
    public int PostId { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    [Required]
    public User User { get; set; } = null!;
    
    [Required]
    public string Content { get; set; } = null!;
    
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    
    
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    
    
    public ICollection<HashTag> HashTags { get; set; } = new List<HashTag>();
    
}