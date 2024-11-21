using blog_app.Repositories.Interfaces;
using blog_app.Services.Interface;

namespace blog_app.Services.Services;

public class PostsService: IPostsService
{
    private readonly IPostRepository _postRepository;

    public PostsService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

}