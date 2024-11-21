using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_app.Entities;

public class Follow
{
    [Key]
    public int FollowId { get; set; }
    
    [ForeignKey("Follower")]
    public int FollowerId { get; set; }
    
    [Required]
    [NotMapped]
    public User Follower { get; set; } = null!;
    
    [ForeignKey("Following")]
    public int FollowingId { get; set; }
    
    [Required]
    public User Following { get; set; } = null!;
}