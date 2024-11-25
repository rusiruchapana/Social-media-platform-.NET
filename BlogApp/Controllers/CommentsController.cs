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

    [HttpPut("{postId}/comments/{commentId}")]
    public async Task<IActionResult> UpdateComment(int postId, int commentId, CommentsRequestDTO commentsRequestDto)
    {
        CommentsResponseDTO commentsResponseDto = await _commentsService.UpdateComment(postId, commentId, commentsRequestDto);
        return Ok(commentsResponseDto);
    }
    
    
    [HttpDelete("{postId}/comments/{commentId}")]
    public async Task<IActionResult> DeleteComment(int postId, int commentId)
    {
        bool isDeleted = await _commentsService.DeleteComment(postId , commentId);

        if (isDeleted == false)
            return BadRequest("Comment not found or does not belong to the specified post.");
        
        return Ok("Comment successfully deleted.");
    }
    

    




}