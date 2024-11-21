using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_app.Entities;

public class Like
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LikeId { get; set; }
    
    [ForeignKey("Post")]
    public int PostId { get; set; }
    
    [Required]
    public Post Post { get; set; } = null!;
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    
    public User User { get; set; } = null!;
}