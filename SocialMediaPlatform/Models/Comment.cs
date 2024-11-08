namespace SocialMediaPlatform.Models;

public class Comment
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}