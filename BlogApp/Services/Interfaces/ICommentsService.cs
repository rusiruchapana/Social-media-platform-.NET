using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;

namespace BlogApp.Services.Interfaces;

public interface ICommentsService
{
    Task<CommentsResponseDTO> CreateComments(CommentsRequestDTO commentsRequestDto);
}