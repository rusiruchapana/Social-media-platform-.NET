using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController: ControllerBase
{
    private readonly ICommentsService _commentsService;

    public CommentsController(ICommentsService commentsService)
    {
        _commentsService = commentsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComments(CommentsRequestDTO commentsRequestDto)
    {
        CommentsResponseDTO commentsResponseDto = await _commentsService.CreateComments(commentsRequestDto);
        return Created("" , commentsResponseDto);
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetComments(int postId)
    {
        IEnumerable<CommentsResponseDTO> commentsResponseDtos = await _commentsService.GetComments(postId);
        return Ok(commentsResponseDtos);
    }

    [HttpGet("{postId}/comments/{commentId}")]
    public async Task<IActionResult> GetCommentById(int postId, int commentId)
    {
        CommentsResponseDTO commentsResponseDto = await _commentsService.GetCommentById(postId , commentId);
        return Ok(commentsResponseDto);
    }



}