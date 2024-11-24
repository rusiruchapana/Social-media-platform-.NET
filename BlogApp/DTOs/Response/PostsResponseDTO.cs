using BlogApp.Models;

namespace BlogApp.DTOs.Response;

public class PostsResponseDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Comment> Comments { get; set; }
}