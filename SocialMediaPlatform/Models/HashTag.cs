namespace SocialMediaPlatform.Models;

public class HashTag
{
    public int HashTagId { get; set; }
    public string Name { get; set; }
    public ICollection<Post> Posts { get; set; }
}