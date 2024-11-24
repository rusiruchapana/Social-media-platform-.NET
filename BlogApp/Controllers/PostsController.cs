using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController: ControllerBase
{
    private readonly IPostsService _postsService;

    public PostsController(IPostsService postsService)
    {
        _postsService = postsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(PostsRequestDTO postsRequestDto)
    {
        PostsResponseDTO postsResponseDto = await _postsService.CreatePost(postsRequestDto);
        return Created("" , postsResponseDto);
    }
}