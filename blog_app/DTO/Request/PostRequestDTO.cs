using blog_app.Entities;

namespace blog_app.DTO.Request;

public class PostRequestDTO
{
    public int UserId { get; set; }
    public string Content { get; set; } = null!;
    public ICollection<HashTag> HashTags { get; set; } = new List<HashTag>();
}