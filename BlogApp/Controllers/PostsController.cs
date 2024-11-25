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

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        IEnumerable<PostsResponseDTO> postsResponseDtos = await _postsService.GetAllPosts();
        return Ok(postsResponseDtos);
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        PostsResponseDTO postsResponseDto = await _postsService.GetPostById(id);
        return Ok(postsResponseDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePost(int id , PostsRequestDTO postsRequestDto)
    {
        PostsResponseDTO postsResponseDto = await _postsService.UpdatePost(id , postsRequestDto);
        return Ok(postsResponseDto);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePost(int id)
    {
        bool isDeleted = await _postsService.DeletePost(id);
        if (isDeleted == false)
            return BadRequest("No post was found");
            
        return Ok("Post deleted successfully");
        
    }

}