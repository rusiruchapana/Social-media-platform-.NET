using blog_app.Entities;

namespace blog_app.DTO.Response;

public class PostResponseDTO
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<HashTag> HashTags { get; set; } = new List<HashTag>();

}