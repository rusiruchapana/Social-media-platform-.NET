using BlogApp.Models;

namespace BlogApp.DTOs.Response;

public class CommentsResponseDTO
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
}