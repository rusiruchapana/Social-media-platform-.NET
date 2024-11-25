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

}