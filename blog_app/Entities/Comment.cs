using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_app.Entities;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CommentId { get; set; }
    
    [ForeignKey("Post")]
    public int PostId { get; set; }
    
    [Required]
    public Post Post { get; set; } = null!;
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    [Required]
    public User User { get; set; } = null!;
    
    [Required]
    public string Content { get; set; } = null!;
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}