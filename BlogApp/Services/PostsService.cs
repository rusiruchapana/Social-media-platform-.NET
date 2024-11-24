using BlogApp.Repositories.Interfaces;
using BlogApp.Services.Interfaces;

namespace BlogApp.Services;

public class PostsService: IPostsService
{
    private readonly IPostsRepository _postsRepository;

    public PostsService(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }
}