using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_app.Entities;

public class Like
{
    [Key]
    public int LikeId { get; set; }
    
    [ForeignKey("Post")]
    public int PostId { get; set; }
    
    [Required]
    public Post Post { get; set; } = null!;
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    [NotMapped]
    public User User { get; set; } = null!;
}