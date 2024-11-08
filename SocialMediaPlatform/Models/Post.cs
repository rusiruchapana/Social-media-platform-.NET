namespace SocialMediaPlatform.Models;

public class Post
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<HashTag> HashTags { get; set; }
    
    
    
}