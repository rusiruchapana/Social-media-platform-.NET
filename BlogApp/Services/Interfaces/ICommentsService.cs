using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;

namespace BlogApp.Services.Interfaces;

public interface ICommentsService
{
    Task<CommentsResponseDTO> CreateComments(CommentsRequestDTO commentsRequestDto);

    Task<IEnumerable<CommentsResponseDTO>> GetComments(int postId);
    Task<CommentsResponseDTO> GetCommentById(int postId, int commentId);
    Task<CommentsResponseDTO> UpdateComment(int postId, int commentId, CommentsRequestDTO commentsRequestDto);
    Task<bool> DeleteComment(int postId, int commentId);
}