using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;

namespace BlogApp.Repositories;

public class PostsRepository: IPostsRepository
{
    private readonly ApplicationDbContext _context;

    public PostsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Post> CreatePost(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return post;
    }
}