using blog_app.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace blog_app.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController: Controller
{
    private readonly IPostsService _postsService;

    public PostsController(IPostsService postsService)
    {
        _postsService = postsService;
    }
}