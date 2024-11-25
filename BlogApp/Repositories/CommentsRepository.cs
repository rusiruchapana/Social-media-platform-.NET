using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;

namespace BlogApp.Repositories;

public class CommentsRepository: ICommentsRepository
{
    private readonly ApplicationDbContext _context;

    public CommentsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateComments(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return comment;
    }
}