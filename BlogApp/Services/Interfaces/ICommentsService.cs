using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;

namespace BlogApp.Services.Interfaces;

public interface ICommentsService
{
    Task<CommentsResponseDTO> CreateComments(CommentsRequestDTO commentsRequestDto);

    Task<IEnumerable<CommentsResponseDTO>> GetComments(int postId);
    Task<CommentsResponseDTO> GetCommentById(int postId, int commentId);
}