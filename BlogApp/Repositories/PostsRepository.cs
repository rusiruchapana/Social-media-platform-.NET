using BlogApp.Data;
using BlogApp.Repositories.Interfaces;

namespace BlogApp.Repositories;

public class PostsRepository: IPostsRepository
{
    private readonly ApplicationDbContext _context;

    public PostsRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}