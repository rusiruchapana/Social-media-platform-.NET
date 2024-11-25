using AutoMapper;
using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;
using BlogApp.Services.Interfaces;

namespace BlogApp.Services;

public class CommentsService: ICommentsService
{
    private readonly ICommentsRepository _commentsRepository;
    private readonly IMapper _mapper;

    public CommentsService(ICommentsRepository commentsRepository , IMapper mapper)
    {
        _commentsRepository = commentsRepository;
        _mapper = mapper;
    }

    public async Task<CommentsResponseDTO> CreateComments(CommentsRequestDTO commentsRequestDto)
    {
        Comment comment = _mapper.Map<Comment>(commentsRequestDto);
        Comment savedComment = await _commentsRepository.CreateComments(comment);

        CommentsResponseDTO commentsResponseDto = _mapper.Map<CommentsResponseDTO>(savedComment);
        return commentsResponseDto;
    }

    public async Task<IEnumerable<CommentsResponseDTO>> GetComments(int postId)
    {
        IEnumerable<Comment> comments = await _commentsRepository.GetComments(postId);
        IEnumerable<CommentsResponseDTO> commentsResponseDtos = _mapper.Map<IEnumerable<CommentsResponseDTO>>(comments);
        return commentsResponseDtos;
    }

    public async Task<CommentsResponseDTO> GetCommentById(int postId, int commentId)
    {
        Comment comment = await _commentsRepository.GetCommentById(postId , commentId);
        CommentsResponseDTO commentsResponseDto = _mapper.Map<CommentsResponseDTO>(comment);
        return commentsResponseDto;
    }

    public async Task<CommentsResponseDTO> UpdateComment(int postId, int commentId, CommentsRequestDTO commentsRequestDto)
    {
        Comment convertComment = _mapper.Map<Comment>(commentsRequestDto); 
        Comment comment = await _commentsRepository.UpdateComment(postId, commentId, convertComment);
        CommentsResponseDTO commentsResponseDto = _mapper.Map<CommentsResponseDTO>(comment);
        return commentsResponseDto;
    }

    public async Task<bool> DeleteComment(int postId, int commentId)
    {
        bool isDeleted = await _commentsRepository.DeleteComment(postId , commentId);
        return isDeleted;
    }
}