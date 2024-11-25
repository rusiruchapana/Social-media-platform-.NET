using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Comment>> GetComments(int postId)
    {
        IEnumerable<Comment> comments = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
        return comments;
    }

    public  async Task<Comment> GetCommentById(int postId, int commentId)
    {
        Comment comment = await _context.Comments.Where(c => c.PostId == postId && c.Id == commentId).FirstOrDefaultAsync();
        return comment;
    }

    public async Task<Comment> UpdateComment(int postId, int commentId, Comment convertComment)
    {
        Comment savedComment = await _context.Comments.Where(c => c.PostId == postId && c.Id == commentId).FirstOrDefaultAsync();
        savedComment.Text = convertComment.Text;
        _context.Comments.Update(savedComment);
        await _context.SaveChangesAsync();
        return savedComment;
    }

    public async Task<bool> DeleteComment(int postId, int commentId)
    {
        Comment comment = await _context.Comments.Where(c => c.PostId == postId && c.Id == commentId).FirstOrDefaultAsync();

        if (comment == null)
            return false;
        
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }
}