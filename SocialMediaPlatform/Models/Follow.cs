
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaPlatform.Models;

public class Follow
{
    [Key]
    public int FollowId { get; set; }
    
    [ForeignKey("Follower")]
    public int FollowerId { get; set; }
    
    
    public virtual User Follower { get; set; }
    
    [ForeignKey("Following")]
    public int FollowingId { get; set; }
    
    
    public virtual User Following { get; set; }
}