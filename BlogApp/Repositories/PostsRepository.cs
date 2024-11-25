using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        IEnumerable<Post> posts = await _context.Posts.ToListAsync();
        return posts;
    }

    public async Task<Post> GetPostById(int id)
    {
        Post post = await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
        return post;
    }

    public async Task<Post> UpdatePost(int id, Post post)
    {
        Post check = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (check == null)
            throw new KeyNotFoundException($"Post with ID {id} was not found.");

        check.Title = post.Title;
        check.Content = post.Content;

        _context.Posts.Update(check);
        await _context.SaveChangesAsync();
        return check;
    }

    public async Task<bool> DeletePost(int id)
    {
        Post post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post == null)
            return false;

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return true;
    }
}